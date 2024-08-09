using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace Coupled_mass_spring_system.solver
{
    internal class transient_resp_solver
    {
        // Number of degrees of freedom
        private int num_DOF = 0;

        // Mass matrix
        private Matrix<double> massMatrix;

        // Stiffness matrix
        private Matrix<double> stiffnessMatrix;

        // Modal Damping 
        private Vector<double> modalzeta;

        // Initial displacements
        private Vector<double> initialDisplacements;

        // Initial velocities
        private Vector<double> initialVelocities;

        // Force amplitudes
        private Vector<double> forceAmplitudes;

        // Force frequencies
        private Vector<double> forceFrequencies;

        // Angular natural frequencies and Normal modes
        private Vector<double> angularNaturalFrequencies;
        private Matrix<double> normModeShapes;
        private Matrix<double> inv_normModeShapes;

        // Modal co-ordinate data
        private Vector<double> modalMass;
        private Vector<double> modalStiffness;
        private Vector<double> modalIDispl;
        private Vector<double> modalIVelo;

        // Analysis solver settings
        private double startTime;
        private double endTime;
        private double timeInterval;

        // Final results
        private Matrix<double> displacement;
        private Matrix<double> velocity;
        private Matrix<double> acceleration;


        // Constructor to initialize the solver with the number of DOF
        public transient_resp_solver(int num_DOF)
        {
            this.num_DOF = num_DOF;
            massMatrix = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            stiffnessMatrix = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            modalzeta = Vector<double>.Build.Dense(num_DOF);
            initialDisplacements = Vector<double>.Build.Dense(num_DOF);
            initialVelocities = Vector<double>.Build.Dense(num_DOF);
            forceAmplitudes = Vector<double>.Build.Dense(num_DOF);
            forceFrequencies = Vector<double>.Build.Dense(num_DOF);

            // Set the angular frequencies and normalized mode shapes
            angularNaturalFrequencies = Vector<double>.Build.Dense(num_DOF);
            normModeShapes = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            inv_normModeShapes = Matrix<double>.Build.Dense(num_DOF, num_DOF);

            // Modal co-ordinate data
            modalMass = Vector<double>.Build.Dense(num_DOF);
            modalStiffness = Vector<double>.Build.Dense(num_DOF);
            modalIDispl = Vector<double>.Build.Dense(num_DOF);
            modalIVelo = Vector<double>.Build.Dense(num_DOF);



        }


        // Method to set mass matrix
        public void SetMassMatrix(double[,] masses)
        {
            massMatrix = Matrix<double>.Build.DenseOfArray(masses);
        }

        // Method to set stiffness matrix
        public void SetStiffnessMatrix(double[,] stiffnesses)
        {
            stiffnessMatrix = Matrix<double>.Build.DenseOfArray(stiffnesses);
        }

        // Method to set damping matrix
        public void SetModalDamping(double[] zeta)
        {
            modalzeta = Vector<double>.Build.DenseOfArray(zeta);
        }

        // Method to set initial conditions
        public void SetInitialConditions(double[] displacements, double[] velocities)
        {
            initialDisplacements = Vector<double>.Build.DenseOfArray(displacements);
            initialVelocities = Vector<double>.Build.DenseOfArray(velocities);
        }

        // Method to set force data
        public void SetForceData(double[] amplitudes, double[] frequencies)
        {
            forceAmplitudes = Vector<double>.Build.DenseOfArray(amplitudes);
            forceFrequencies = Vector<double>.Build.DenseOfArray(frequencies);
        }

        // Method to set analysis settings
        public void SetAnalysisSettings(double start, double end, double interval)
        {
            startTime = start;
            endTime = end;
            timeInterval = interval;
        }

        static Matrix<double> NormalizeColumns(Matrix<double> matrix)
        {
            var result = matrix.Clone();

            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                var column = result.Column(i);
                var maxAbsValue = column.AbsoluteMaximum();
                result.SetColumn(i, column / maxAbsValue);
            }

            return result;
        }


        // Method to perform eigenvalue calculation
        private void PerformEigenvalueCalculation()
        {
            // Eigenvalues and eigenvectors
            Matrix<double> Z_matrix = massMatrix.Inverse() * stiffnessMatrix;
            Evd<double> eigen = Z_matrix.Evd();
            Vector<double> eigenvalues = eigen.EigenValues.Real();
            Matrix<double> eigenvectors = eigen.EigenVectors;

            // Sort eigenvalues and eigenvectors
            int[] sortedIndices = eigenvalues.Select((value, index) => new { value, index })
                                           .OrderBy(e => e.value)
                                           .Select(e => e.index)
                                           .ToArray();

            Vector<double> angularNaturalFrequencies = Vector<double>.Build.Dense(sortedIndices.Length);
            for (int i = 0; i < sortedIndices.Length; i++)
            {
                angularNaturalFrequencies[i] = Math.Sqrt(Math.Abs(eigenvalues[sortedIndices[i]]));
            }

            Matrix<double> modeShapes = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            for (int i = 0; i < num_DOF; i++)
            {
                modeShapes.SetColumn(i, eigenvectors.Column(sortedIndices[i]));
            }

            Matrix<double> normModeShapes = NormalizeColumns(modeShapes);

            // Store the results in the class
            this.angularNaturalFrequencies = angularNaturalFrequencies;
            this.normModeShapes = normModeShapes;
            this.inv_normModeShapes = normModeShapes.Inverse();
        }

        // Method to perform modal superposition
        private void PerformModalSuperposition()
        {
            // Perform modal superposition on mass matrix & stiffness matrix
            this.modalMass = (this.normModeShapes.Transpose() * this.massMatrix * this.normModeShapes).Diagonal();
            this.modalStiffness = (this.normModeShapes.Transpose() * this.stiffnessMatrix * this.normModeShapes).Diagonal();

            // Transform the initial displacement and initial velocities
            this.modalIDispl = this.inv_normModeShapes * this.initialDisplacements;
            this.modalIVelo = this.inv_normModeShapes * this.initialVelocities;

        }

        private void PerformResponseCalculation()
        {
            // Arrange the time
            int numTimeSteps = (int)Math.Ceiling((endTime - startTime) / timeInterval);
            Vector<double> t_eval = Vector<double>.Build.Dense(numTimeSteps, i => i * timeInterval);

            // Result variables
            this.displacement = Matrix<double>.Build.Dense(num_DOF, numTimeSteps);
            this.velocity = Matrix<double>.Build.Dense(num_DOF, numTimeSteps);
            this.acceleration = Matrix<double>.Build.Dense(num_DOF, numTimeSteps);

            // Find the response at time step
            for (int i = 0; i < t_eval.Count; i++)
            {
                double t = t_eval[i];
                Vector<double> disp_at_t = Vector<double>.Build.Dense(num_DOF);
                Vector<double> velo_at_t = Vector<double>.Build.Dense(num_DOF);
                Vector<double> accl_at_t = Vector<double>.Build.Dense(num_DOF);

                // Go through every mode
                for (int j = 0; j < num_DOF; j++)
                {
                    double mass = this.modalMass[j]; // modal mass m of mode j
                    double stiff = this.modalStiffness[j]; // modal stiffness k of mode j
                    double zeta = this.modalzeta[j]; // modal damp c of mode j
                    double disp_i = this.modalIDispl[j]; // modal initial displ of mode j
                    double velo_i = this.modalIVelo[j]; // modal initial velo of mode j

                    var transientResponse = TransientInitialConditionResponse(t, mass, stiff, zeta, disp_i, velo_i);
                    var forcedResponse = CalculateForcedResponse(t, j, mass, stiff, zeta);

                    disp_at_t[j] = transientResponse.displacement + forcedResponse.displacement;
                    velo_at_t[j] = transientResponse.velocity + forcedResponse.velocity;
                    accl_at_t[j] = transientResponse.acceleration + forcedResponse.acceleration;
                }

                this.displacement.SetColumn(i, this.normModeShapes * disp_at_t);
                this.velocity.SetColumn(i, this.normModeShapes * velo_at_t);
                this.acceleration.SetColumn(i, this.normModeShapes * velo_at_t);
            }
        }

        // Solver method
        public void Solve()
        {
            // Implementation of the solver for transient response
            // Step 1: Perform eigenvalue analysis
            PerformEigenvalueCalculation();

            // Step 2: Perform modal superposition (transform physical co-ordinate to modal co-ordinates)
            PerformModalSuperposition();

            // Step 3: Calculate the response
            PerformResponseCalculation();

            // End
        }


        private (double displacement, double velocity, double acceleration) TransientInitialConditionResponse(
            double time_t,
            double mass,
            double stiff,
            double zeta,
            double i_disp,
            double i_velo)
        {
            // omega n
            double omega_n = Math.Sqrt(stiff / mass);

            // omega D
            double omega_nD = omega_n * Math.Sqrt(1 - (zeta * zeta));

            // Exponential Damping factor
            double c_factor = zeta * omega_n;
            double exp_damp_factor = Math.Exp(-1.0 * c_factor * time_t);

            // A & B Constants
            double A_const = i_disp;
            double B_const = (i_velo + (zeta * omega_n * i_disp)) / omega_nD;

            // Displacement response
            // e^(-c * t) * (A * cos(w * t) + B * sin(w * t))
            double transientinl_displ_resp = exp_damp_factor * ((A_const * Math.Cos(omega_nD * time_t)) + (B_const * Math.Sin(omega_nD * time_t)));

            // Velocity response
            // -e^(-c * t) * ((A * w + B * c) * sin(w * t) + (A * c - B * w) * cos(w * t))
            double v_factor1 = (A_const * omega_nD) + (B_const * c_factor);
            double v_factor2 = (A_const * c_factor) - (B_const * omega_nD);
            double transientinl_velo_resp = -1.0 * exp_damp_factor * ((v_factor1 * Math.Sin(omega_nD * time_t)) + (v_factor2 * Math.Cos(omega_nD * time_t)));

            // Acceleration response
            // -e^(-c * t) * ((B * w^2 - 2 * A * c * w - B * c^2) * sin(w * t) + (A * w^2 + 2 * B * c * w - A * c^2) * cos(w * t))
            double a_factor1 = (B_const * (omega_nD * omega_nD)) - (2.0 * A_const * c_factor * omega_nD) - (B_const * (c_factor * c_factor));
            double a_factor2 = (A_const * (omega_nD * omega_nD)) + (2.0 * B_const * c_factor * omega_nD) - (A_const * (c_factor * c_factor));
            double transientinl_accl_resp = -1.0 * exp_damp_factor * ((a_factor1 * Math.Sin(omega_nD * time_t)) + (a_factor2 * Math.Cos(omega_nD * time_t)));

            return (transientinl_displ_resp, transientinl_velo_resp, transientinl_accl_resp);
        }

        private (double displacement, double velocity, double acceleration) CalculateForcedResponse(
            double t,
            int j,
            double mass,
            double stiff,
            double zeta)
        {
            double displResponseForce = 0.0;
            double veloResponseForce = 0.0;
            double acclResponseForce = 0.0;

            for (int k = 0; k < num_DOF; k++)
            {
                double f_ampl_k = this.normModeShapes[k, j] * this.forceAmplitudes[k];
                double f_freq_k = this.forceFrequencies[k];
                var forceResponse = ForcedResponseSoln(t, mass, stiff, zeta, f_ampl_k, f_freq_k);

                displResponseForce += forceResponse.displacement;
                veloResponseForce += forceResponse.velocity;
                acclResponseForce += forceResponse.acceleration;
            }

            return (displResponseForce, veloResponseForce, acclResponseForce);
        }

        private (double displacement, double velocity, double acceleration) ForcedResponseSoln(
            double time_t,
            double mass,
            double stiff,
            double zeta,
            double force_ampl,
            double force_freq)
        {
            // Transient Forced Response
            var transientResponse = TransientForcedResponse(time_t, mass, stiff, zeta, force_ampl, force_freq);
            double transientDispl = transientResponse.displacement;
            double transientVelo = transientResponse.velocity;
            double transientAccl = transientResponse.acceleration;

            // Steady State Forced Response
            var steadyStateResponse = SteadyStateForcedResponse(time_t, mass, stiff, zeta, force_ampl, force_freq);
            double steadyStateDispl = steadyStateResponse.displacement;
            double steadyStateVelo = steadyStateResponse.velocity;
            double steadyStateAccl = steadyStateResponse.acceleration;

            // Total Forced Response
            double totalForcedDispl = transientDispl + steadyStateDispl;
            double totalForcedVelo = transientVelo + steadyStateVelo;
            double totalForcedAccl = transientAccl + steadyStateAccl;

            return (totalForcedDispl, totalForcedVelo, totalForcedAccl);
        }

        private (double displacement, double velocity, double acceleration) TransientForcedResponse(
            double time_t,
            double mass,
            double stiff,
            double zeta,
            double force_ampl,
            double force_freq)
        {
            // Modal omega n
            double omega_n = Math.Sqrt(stiff / mass);

            // Modal omega D
            double omega_nD = omega_n * Math.Sqrt(1 - (zeta * zeta));

            // Force omega
            double force_omega = 2.0 * Math.PI * force_freq;

            // Damping factor
            double c_factor = zeta * omega_n;
            double exp_damp_factor = Math.Exp(-1.0 * c_factor * time_t);

            // A Constant Factor
            double u_static = force_ampl / stiff;

            double R_d_factor1 = 1.0 - ((force_omega / omega_n) * (force_omega / omega_n));
            double R_d_factor2 = 2.0 * zeta * (force_omega / omega_n);

            // B Constant Factor
            double freq_ratio = force_omega / omega_nD;
            double B_factor1 = 2.0 * (zeta * zeta) * freq_ratio;

            double B_const1 = (u_static * B_factor1) / ((R_d_factor1 * R_d_factor1) + (R_d_factor2 * R_d_factor2));
            double B_const2 = (u_static * freq_ratio * R_d_factor1) / ((R_d_factor1 * R_d_factor1) + (R_d_factor2 * R_d_factor2));

            // A & B Constants
            double A_const = (u_static * R_d_factor2) / ((R_d_factor1 * R_d_factor1) + (R_d_factor2 * R_d_factor2));
            double B_const = B_const1 - B_const2;

            // Displacement response
            double transientF_displ_resp = exp_damp_factor * ((A_const * Math.Cos(omega_nD * time_t)) + (B_const * Math.Sin(omega_nD * time_t)));

            // Velocity response
            // -e^(-c * t) * ((A * w + B * c) * sin(w * t) + (A * c - B * w) * cos(w * t))
            double v_factor1 = (A_const * omega_nD) + (B_const * c_factor);
            double v_factor2 = (A_const * c_factor) - (B_const * omega_nD);
            double transientF_velo_resp = -1.0 * exp_damp_factor * ((v_factor1 * Math.Sin(omega_nD * time_t)) + (v_factor2 * Math.Cos(omega_nD * time_t)));

            // Acceleration response
            // -e^(-c * t) * ((B * w^2 - 2 * A * c * w - B * c^2) * sin(w * t) + (A * w^2 + 2 * B * c * w - A * c^2) * cos(w * t))
            double a_factor1 = (B_const * (omega_nD * omega_nD)) - (2.0 * A_const * c_factor * omega_nD) - (B_const * (c_factor * c_factor));
            double a_factor2 = (A_const * (omega_nD * omega_nD)) + (2.0 * B_const * c_factor * omega_nD) - (A_const * (c_factor * c_factor));
            double transientF_accl_resp = -1.0 * exp_damp_factor * ((a_factor1 * Math.Sin(omega_nD * time_t)) + (a_factor2 * Math.Cos(omega_nD * time_t)));

            return (transientF_displ_resp, transientF_velo_resp, transientF_accl_resp);
        }


        private (double displacement, double velocity, double acceleration) SteadyStateForcedResponse(
            double time_t,
            double mass,
            double stiff,
            double zeta,
            double force_ampl,
            double force_freq)
        {
            // Static displacement (u_st = p0/k)
            double u_static = force_ampl / stiff;

            // omega n
            double omega_n = Math.Sqrt(stiff / mass);

            // Force omega (omega_f = 2 * pi * freq_f)
            double force_omega = 2.0 * Math.PI * force_freq;

            // Deformation response factor
            double R_d_factor1 = 1.0 - Math.Pow(force_omega / omega_n, 2);
            double R_d_factor2 = 2.0 * zeta * (force_omega / omega_n);

            // For resonance case without damping (at resonance frequency)
            if (zeta == 0 && R_d_factor1 == 0)
            {
                // Displacement response
                double resonant_displ_resp = 0.0;


                // Velocity response
                double resonant_velo_resp = 0.0;


                // Acceleration response
                double resonant_accl_resp = 0.0;

                return (resonant_displ_resp, resonant_velo_resp, resonant_accl_resp);
            }

            double R_d = 1.0 / Math.Sqrt(Math.Pow(R_d_factor1, 2) + Math.Pow(R_d_factor2, 2));

            // Phase value
            double phi = Math.Atan2(R_d_factor2, R_d_factor1);

            // Displacement response
            double steadyF_displ_resp = u_static * R_d * Math.Sin((force_omega * time_t) - phi);

            // Static velocity (v_st = p0/sqrt(km))
            double v_static = force_ampl / Math.Sqrt(stiff * mass);

            // Velocity response factor
            double R_v = (force_omega / omega_n) * R_d;

            // Velocity response
            double steadyF_velo_resp = v_static * R_v * Math.Cos((force_omega * time_t) - phi);

            // Static acceleration (a_st = p0/m)
            double a_static = force_ampl / mass;

            // Acceleration response factor
            double R_a = Math.Pow(force_omega / omega_n, 2) * R_d;

            // Acceleration response
            double steadyF_accl_resp = -1.0 * a_static * R_a * Math.Sin((force_omega * time_t) - phi);

            return (steadyF_displ_resp, steadyF_velo_resp, steadyF_accl_resp);
        }

    }
}
