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
    internal class frequency_resp_solver
    {
        // Number of degrees of freedom
        private int num_DOF = 0;

        // Mass matrix
        private Matrix<double> massMatrix;

        // Stiffness matrix
        private Matrix<double> stiffnessMatrix;

        // Modal Damping 
        private Vector<double> modalzeta;

        // Force amplitudes
        private Vector<double> forceAmplitudes;

        // Force frequencies
        private Vector<double> forceFrequencies;


        // Angular natural frequencies, Natural frequencies and Normal modes
        private Vector<double> angularNaturalFrequencies;
        private Vector<double> naturalFrequencies;
        private Matrix<double> normModeShapes;


        // Modal co-ordinate data
        private Vector<double> modalMass;
        private Vector<double> modalStiffness;

        // Analysis solver settings
        private bool isFreqAutoSelect = false;
        private double startffreq;
        private double endffreq;
        private double ffreqInterval;

        // Final results
        private Vector<double> freq_eval;
        private Matrix<double> displacement;
        private Matrix<double> velocity;
        private Matrix<double> acceleration;


        public List<double> GetFrequencydata()
        {
            return this.freq_eval.ToList();
        }

        public List<double> GetDisplacement(int rowIndex)
        {
            return this.displacement.Row(rowIndex).ToList();
        }

        public List<double> GetVelocity(int rowIndex)
        {
            return this.velocity.Row(rowIndex).ToList();
        }

        public List<double> GetAcceleration(int rowIndex)
        {
            return this.acceleration.Row(rowIndex).ToList();
        }


        public frequency_resp_solver(int num_DOF)
        {
            this.num_DOF = num_DOF;
            massMatrix = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            stiffnessMatrix = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            modalzeta = Vector<double>.Build.Dense(num_DOF);

            forceAmplitudes = Vector<double>.Build.Dense(num_DOF);
            forceFrequencies = Vector<double>.Build.Dense(num_DOF);

            // Set the angular frequencies, natural frequencies and normalized mode shapes
            angularNaturalFrequencies = Vector<double>.Build.Dense(num_DOF);
            naturalFrequencies = Vector<double>.Build.Dense(num_DOF);
            normModeShapes = Matrix<double>.Build.Dense(num_DOF, num_DOF);

            // Modal co-ordinate data
            modalMass = Vector<double>.Build.Dense(num_DOF);
            modalStiffness = Vector<double>.Build.Dense(num_DOF);

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

        // Method to set force data
        public void SetForceData(double[] amplitudes, double[] frequencies)
        {
            forceAmplitudes = Vector<double>.Build.DenseOfArray(amplitudes);
            forceFrequencies = Vector<double>.Build.DenseOfArray(frequencies);
        }

        // Method to set analysis settings
        public void SetAnalysisSettings(bool isAutoSelect,double start, double end, double interval)
        {
            isFreqAutoSelect = isAutoSelect;
            startffreq = start;
            endffreq = end;
            ffreqInterval = interval;
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

            // Angular natural frequencies, Natural frequencies 
            Vector<double> angularNaturalFrequencies = Vector<double>.Build.Dense(sortedIndices.Length);
            Vector<double> naturalFrequencies = Vector<double>.Build.Dense(sortedIndices.Length);
            for (int i = 0; i < sortedIndices.Length; i++)
            {
                double omega_n = Math.Sqrt(Math.Abs(eigenvalues[sortedIndices[i]]));
                angularNaturalFrequencies[i] = omega_n;
                naturalFrequencies[i] = omega_n / (2.0 * Math.PI);
            }

            // Get the minimum of force frequency factor
            double min_freq_factor = double.MaxValue;
            for (int i = 0; i < num_DOF; i++)
            {
                if(this.forceAmplitudes[i] !=0.0)
                {
                    min_freq_factor = Math.Min(min_freq_factor,this.forceFrequencies[i]);
                }
            }


            // Steps to auto create frequency range
            if (isFreqAutoSelect == true)
            {
                // Set the start frequency as always 0.0001
                startffreq = 0.0001;

                if (angularNaturalFrequencies.Count == 1)
                {
                    endffreq = (2 * angularNaturalFrequencies[0])/ ( 2.0 * Math.PI * min_freq_factor);
                }
                else
                {
                    double maxGap = 0;
                    for (int i = 1; i < angularNaturalFrequencies.Count; i++)
                    {
                        double gap = angularNaturalFrequencies[i] - angularNaturalFrequencies[i - 1];
                        if (gap > maxGap)
                        {
                            maxGap = gap;
                        }
                    }
                    endffreq = (angularNaturalFrequencies[angularNaturalFrequencies.Count - 1] + Math.Max(angularNaturalFrequencies[0], maxGap)) / (2.0 * Math.PI * min_freq_factor);
                }

               ffreqInterval = (endffreq - startffreq) / 1000.0;
            }

            Matrix<double> modeShapes = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            for (int i = 0; i < num_DOF; i++)
            {
                modeShapes.SetColumn(i, eigenvectors.Column(sortedIndices[i]));
            }

            Matrix<double> normModeShapes = NormalizeColumns(modeShapes);

            // Store the results in the class
            this.angularNaturalFrequencies = angularNaturalFrequencies;
            this.naturalFrequencies = naturalFrequencies;
            this.normModeShapes = normModeShapes;
        }

        // Method to perform modal superposition
        private void PerformModalSuperposition()
        {
            // Perform modal superposition on mass matrix & stiffness matrix
            this.modalMass = (this.normModeShapes.Transpose() * this.massMatrix * this.normModeShapes).Diagonal();
            this.modalStiffness = (this.normModeShapes.Transpose() * this.stiffnessMatrix * this.normModeShapes).Diagonal();

        }

        private void PerformResponseCalculation()
        {
            // Arrange the frequency
            // Generate the regular frequency range
            int numFreqSteps = (int)Math.Ceiling((endffreq - startffreq) / ffreqInterval);
            var freqEval = Vector<double>.Build.Dense(numFreqSteps, i => startffreq + i * ffreqInterval);

            if(isFreqAutoSelect == true)
            {
                // Get the minimum of force frequency factor
                double min_freq_factor = double.MaxValue;
                for (int i = 0; i < num_DOF; i++)
                {
                    if (this.forceAmplitudes[i] != 0.0)
                    {
                        min_freq_factor = Math.Min(min_freq_factor, this.forceFrequencies[i]);
                    }
                }

                // Combine the natural frequencies with the regular frequency range
                var combinedFrequencies = new List<double>(freqEval);
                combinedFrequencies.AddRange(this.naturalFrequencies.Select(f => f / min_freq_factor));

                // Sort the combined frequencies
                combinedFrequencies.Sort();

                // Remove duplicates to ensure unique frequencies
                var uniqueFrequencies = combinedFrequencies.Distinct().ToList();

                // Convert back to a Vector
                this.freq_eval = Vector<double>.Build.DenseOfEnumerable(uniqueFrequencies);
            }
            else
            {
                // Frequency inputs are given (Do not add natural frequencies to list
                this.freq_eval = freqEval; // Vector<double>.Build.DenseOfEnumerable(uniqueFrequencies);
            }


            numFreqSteps = this.freq_eval.Count;

            // Result variables
            this.displacement = Matrix<double>.Build.Dense(num_DOF, numFreqSteps);
            this.velocity = Matrix<double>.Build.Dense(num_DOF, numFreqSteps);
            this.acceleration = Matrix<double>.Build.Dense(num_DOF, numFreqSteps);

            // Find the response at time step
            for (int i = 0; i < freq_eval.Count; i++)
            {
                double ffreq = freq_eval[i];
                Vector<double> disp_at_f = Vector<double>.Build.Dense(num_DOF);
                Vector<double> velo_at_f = Vector<double>.Build.Dense(num_DOF);
                Vector<double> accl_at_f = Vector<double>.Build.Dense(num_DOF);

                // Go through every mode
                for (int j = 0; j < num_DOF; j++)
                {
                    double mass = this.modalMass[j]; // modal mass m of mode j
                    double stiff = this.modalStiffness[j]; // modal stiffness k of mode j
                    double zeta = this.modalzeta[j]; // modal damp c of mode j

                    var forcedResponse = CalculateForcedResponse(ffreq, j, mass, stiff, zeta);

                    disp_at_f[j] = forcedResponse.displacement;
                    velo_at_f[j] = forcedResponse.velocity;
                    accl_at_f[j] = forcedResponse.acceleration;
                }

                this.displacement.SetColumn(i, this.normModeShapes * disp_at_f);
                this.velocity.SetColumn(i, this.normModeShapes * velo_at_f);
                this.acceleration.SetColumn(i, this.normModeShapes * velo_at_f);
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


        private (double displacement, double velocity, double acceleration) CalculateForcedResponse(
            double ffreq,
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
                double f_freq_k = this.forceFrequencies[k] * ffreq;
                var forceResponse = maxSteadyStateForcedResponse(mass, stiff, zeta, f_ampl_k, f_freq_k);

                displResponseForce += forceResponse.displacement;
                veloResponseForce += forceResponse.velocity;
                acclResponseForce += forceResponse.acceleration;
            }

            return (displResponseForce, veloResponseForce, acclResponseForce);
        }

        private (double displacement, double velocity, double acceleration) maxSteadyStateForcedResponse(
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

            double R_d = 1.0 / Math.Sqrt(Math.Pow(R_d_factor1, 2) + Math.Pow(R_d_factor2, 2));

            // Phase value
            double phi = Math.Atan2(R_d_factor2, R_d_factor1);

            // Displacement response
            double steadyF_displ_resp = u_static * R_d;

            // Static velocity (v_st = p0/sqrt(km))
            double v_static = force_ampl / Math.Sqrt(stiff * mass);

            // Velocity response factor
            double R_v = (force_omega / omega_n) * R_d;

            // Velocity response
            double steadyF_velo_resp = v_static * R_v;

            // Static acceleration (a_st = p0/m)
            double a_static = force_ampl / mass;

            // Acceleration response factor
            double R_a = Math.Pow(force_omega / omega_n, 2) * R_d;

            // Acceleration response
            double steadyF_accl_resp = -1.0 * a_static * R_a;

            return (steadyF_displ_resp, steadyF_velo_resp, steadyF_accl_resp);
        }




    }
}
