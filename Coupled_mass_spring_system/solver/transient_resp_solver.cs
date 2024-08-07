using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

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

        // Analysis solver settings
        private double startTime;
        private double endTime;
        private double timeInterval;


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

        // Method to perform eigenvalue calculation
        public void PerformEigenvalueCalculation()
        {
            // Eigenvalues and eigenvectors
            var eigen = (massMatrix.Inverse() * stiffnessMatrix).Evd();
            var eigenvalues = eigen.EigenValues.Real();
            var eigenvectors = eigen.EigenVectors;

            // Sort eigenvalues and eigenvectors
            var sortedIndices = eigenvalues.Select((value, index) => new { value, index })
                                           .OrderBy(e => e.value)
                                           .Select(e => e.index)
                                           .ToArray();

            var angularNaturalFrequencies = Vector<double>.Build.Dense(sortedIndices.Length);
            for (int i = 0; i < sortedIndices.Length; i++)
            {
                angularNaturalFrequencies[i] = Math.Sqrt(Math.Abs(eigenvalues[sortedIndices[i]]));
            }

            var modeShapes = Matrix<double>.Build.Dense(num_DOF, num_DOF);
            for (int i = 0; i < num_DOF; i++)
            {
                modeShapes.SetColumn(i, eigenvectors.Column(sortedIndices[i]));
            }

            var normModeShapes = modeShapes.MapColumns(column => column / column.AbsoluteMaximum());

            // Store the results in the class (if needed)
            // this.angularNaturalFrequencies = angularNaturalFrequencies;
            // this.normModeShapes = normModeShapes;
        }



        // Solver method (to be implemented)
        public void Solve()
        {
            // Implementation of the solver for transient response





        }




    }
}
