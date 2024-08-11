﻿using Coupled_mass_spring_system.solver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using System.IO;

namespace Coupled_mass_spring_system
{
    public partial class tResp_form : Form
    {
        // Store the variables
        private double mass_m1 = 0.0;
        private double mass_m2 = 0.0;

        private double stiff_k1 = 0.0;
        private double stiff_k2 = 0.0;
        private double stiff_k3 = 0.0;

        private double zeta1 = 0.0;
        private double zeta2 = 0.0;

        private bool is_analysis_complete = false;

        // Analysis Initial condition and force data
        private double idispl1 = 0.0;
        private double idispl2 = 0.0;

        private double ivelo1 = 0.0;
        private double ivelo2 = 0.0;

        private double fampl1 = 0.0;
        private double fampl2 = 0.0;

        private double ffreq1 = 0.0;
        private double ffreq2 = 0.0;

        // Analysis solver settings
        private double a_starttime = 0.0;
        private double a_endtime = 0.0;
        private double a_timeinterval = 0.0;

        // Main solver variable
        transient_resp_solver solver;

        public tResp_form()
        {
            InitializeComponent();
        }

        public void update_springmodel_data(double t_mass_m1, double t_mass_m2,
                                             double t_stiff_k1, double t_stiff_k2, double t_stiff_k3,
                                             double t_zeta1, double t_zeta2)
        {
            // Update the rich text box with the model data
            richTextBox_modeldata.Text = $"Model Data:\n" +
                                         $"mass m1 = {t_mass_m1}\n" +
                                         $"mass m2 = {t_mass_m2}\n" +
                                         $"_________________________________\n" +
                                         $"Stiffness k1 = {t_stiff_k1}\n" +
                                         $"Stiffness k2 = {t_stiff_k2}\n" +
                                         $"Stiffness k3 = {t_stiff_k3}\n" +
                                         $"_________________________________\n" +
                                         $"Mode 1 damping ratio = {t_zeta1}\n" +
                                         $"Mode 2 damping ratio = {t_zeta2}";

            // Data from the main form
            mass_m1 = t_mass_m1;
            mass_m2 = t_mass_m2;
            stiff_k1 = t_stiff_k1;
            stiff_k2 = t_stiff_k2;
            stiff_k3 = t_stiff_k3;
            zeta1 = t_zeta1;
            zeta2 = t_zeta2;

            // Reset the analysis
            is_analysis_complete = false;
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            // Check whether the inputs in the text boxes are valid
            if (Is_InputDatas_valid() != true)
            {
                return;
            }

            // Input datas are valid proceed with the solve
            // Define the number of DOF
            int num_DOF = 2;

            // Initialize the solver
            solver = new transient_resp_solver(num_DOF);

            // Define the mass matrix for 2 DOF
            double[,] massMatrix = {{ mass_m1, 0.0 },
                                    { 0.0, mass_m2 }};
            solver.SetMassMatrix(massMatrix);

            // Define the stiffness matrix for 2 DOF
            double[,] stiffnessMatrix = {{ stiff_k1 + stiff_k2, -stiff_k2 },
                                         { -stiff_k2, stiff_k2 + stiff_k3 }};
            solver.SetStiffnessMatrix(stiffnessMatrix);

            // Define the damping matrix for 2 DOF
            double[] modaldamping = { zeta1, zeta2 };
            solver.SetModalDamping(modaldamping);

            // Define the initial conditions
            double[] initialDisplacements = { idispl1, idispl2 };
            double[] initialVelocities = { ivelo1, ivelo2 };
            solver.SetInitialConditions(initialDisplacements, initialVelocities);

            // Define the force data
            double[] forceAmplitudes = { fampl1, fampl2 };
            double[] forceFrequencies = { ffreq1, ffreq2 };
            solver.SetForceData(forceAmplitudes, forceFrequencies);

            // Set analysis settings
            solver.SetAnalysisSettings(a_starttime, a_endtime, a_timeinterval);

            // Solve the system
            solver.Solve();

            // Set the analysis complete
            this.is_analysis_complete = true;
        }


        private void button_showresp_Click(object sender, EventArgs e)
        {
            // Check whether the analysis is complete
            if (is_analysis_complete == false)
            {
                return;
            }


            // Analysis is complete
            // Plot options
            //0 Node 1 Displacement Response
            //1 Node 1 Velocity Response
            //2 Node 1 Acceleration Response
            //3 Node 2 Displacement Response
            //4 Node 2 Velocity Response
            //5 Node 2 Acceleration Response

            // List to store datas based on the selected options
            List<List<double>> Displacement_datas = new List<List<double>>();
            List<List<double>> Velocity_datas = new List<List<double>>();
            List<List<double>> Acceleration_datas = new List<List<double>>();

            bool is_Displacement_selected = false;
            bool is_Velocity_selected = false;
            bool is_Acceleration_selected = false;

            // Check which options are selected
            foreach (int index in checkedListBox_respType.CheckedIndices)
            {
                switch (index)
                {
                    case 0:
                        Displacement_datas.Add(solver.GetDisplacement(0));
                        is_Displacement_selected = true;
                        break;
                    case 1:
                        Velocity_datas.Add(solver.GetVelocity(0));
                        is_Velocity_selected = true;
                        break;
                    case 2:
                        Acceleration_datas.Add(solver.GetAcceleration(0));
                        is_Acceleration_selected = true;
                        break;
                    case 3:
                        Displacement_datas.Add(solver.GetDisplacement(1));
                        is_Displacement_selected = true;
                        break;
                    case 4:
                        Velocity_datas.Add(solver.GetVelocity(1));
                        is_Velocity_selected = true;
                        break;
                    case 5:
                        Acceleration_datas.Add(solver.GetAcceleration(1));
                        is_Acceleration_selected = true;
                        break;
                }
            }

            if ((Displacement_datas.Count + Velocity_datas.Count + Acceleration_datas.Count) == 0)
            {
                MessageBox.Show("No options selected for plotting.");
                return;
            }

            // Get the time data
            List<double> time_data = solver.GetTimedata();

            // Create a new PlotModel
            var plotModel = new PlotModel { Title = "Response Plot" };

            if (is_Displacement_selected && is_Velocity_selected && is_Acceleration_selected)
            {
                // 3 Subplots
                AddSubplot(plotModel, time_data, "Displacement", Displacement_datas, 0);
                AddSubplot(plotModel, time_data, "Velocity", Velocity_datas, 1);
                AddSubplot(plotModel, time_data, "Acceleration", Acceleration_datas, 2);
            }
            else if (is_Displacement_selected && is_Velocity_selected)
            {
                // 2 Subplots (Displacement and Velocity)
                AddSubplot(plotModel, time_data, "Displacement", Displacement_datas, 0);
                AddSubplot(plotModel, time_data, "Velocity", Velocity_datas, 1);
            }
            else if (is_Displacement_selected && is_Acceleration_selected)
            {
                // 2 Subplots (Displacement and Acceleration)
                AddSubplot(plotModel, time_data, "Displacement", Displacement_datas, 0);
                AddSubplot(plotModel, time_data, "Acceleration", Acceleration_datas, 1);
            }
            else if (is_Velocity_selected && is_Acceleration_selected)
            {
                // 2 Subplots (Velocity and Acceleration)
                AddSubplot(plotModel, time_data, "Velocity", Velocity_datas, 0);
                AddSubplot(plotModel, time_data, "Acceleration", Acceleration_datas, 1);
            }
            else
            {
                // Single plots
                if (is_Displacement_selected)
                {
                    AddSinglePlot(plotModel, time_data, "Displacement", Displacement_datas);
                }
                else if (is_Velocity_selected)
                {
                    AddSinglePlot(plotModel, time_data, "Velocity", Velocity_datas);
                }
                else
                {
                    AddSinglePlot(plotModel, time_data, "Acceleration", Acceleration_datas);
                }
            }

            // Display the plot in a PlotView (Windows Forms example)
            var plotView = new OxyPlot.WindowsForms.PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };

            this.Controls.Add(plotView);
            plotView.Refresh();
        }


        // Methods to add subplots or single plot
        private void AddSubplot(PlotModel model, List<double> timeData, string yLabel, List<List<double>> data, int position)
        {
            var series = new LineSeries { Title = yLabel };

            for (int i = 0; i < timeData.Count; i++)
            {
                series.Points.Add(new DataPoint(timeData[i], data[0][i])); // Assuming data contains 1D arrays
            }

            model.Series.Add(series);
        }

        private void AddSinglePlot(PlotModel model, List<double> timeData, string yLabel, List<List<double>> data)
        {
            var series = new LineSeries { Title = yLabel };

            for (int i = 0; i < timeData.Count; i++)
            {
                series.Points.Add(new DataPoint(timeData[i], data[0][i])); // Assuming data contains 1D arrays
            }

            model.Series.Add(series);
        }

        private bool Is_InputDatas_valid()
        {
            // Function to check the values of input data
            // Parse and validate Initial displacement and Initial velocity data
            if (!double.TryParse(textBox_idispl1.Text, out double t_idispl1))
            {
                MessageBox.Show("Initial displacement at Node 1 must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_idispl2.Text, out double t_idispl2))
            {
                MessageBox.Show("Initial displacement at Node 2 must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_ivelo1.Text, out double t_ivelo1))
            {
                MessageBox.Show("Initial velocity at Node 1 must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_ivelo2.Text, out double t_ivelo2))
            {
                MessageBox.Show("Initial velocity at Node 2 must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Parse and validate Force amplitude and frequency data
            if (!double.TryParse(textBox_fampl1.Text, out double t_fampl1))
            {
                MessageBox.Show("Force amplitude at Node 1 must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_fampl2.Text, out double t_fampl2))
            {
                MessageBox.Show("Force amplitude at Node 2 must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_ffreq1.Text, out double t_ffreq1) || t_ffreq1 < 0)
            {
                MessageBox.Show("Force frequency at Node 1 must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_ffreq2.Text, out double t_ffreq2) || t_ffreq2 < 0)
            {
                MessageBox.Show("Force frequency at Node 2 must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Parse and validate Analysis settings data
            if (!double.TryParse(textBox_starttime.Text, out double t_starttime) || t_starttime < 0)
            {
                MessageBox.Show("Analysis start time must be zero or a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_endtime.Text, out double t_endtime) || t_endtime < t_starttime)
            {
                MessageBox.Show("Analysis end time must be a positive number and greater than start time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!double.TryParse(textBox_timeinterval.Text, out double t_timeinterval) || t_timeinterval > (t_endtime - t_starttime))
            {
                MessageBox.Show("Analysis time interval must be a positive number and less than the difference between end time and start time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (t_idispl1 == 0 && t_idispl2 == 0 & t_ivelo1 == 0 & t_ivelo2 == 0 & t_fampl1 == 0 & t_fampl2 == 0)
            {
                MessageBox.Show("No initial conditions or force amplitude is given.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (t_idispl1 == 0 && t_idispl2 == 0 & t_ivelo1 == 0 & t_ivelo2 == 0)
            {
                if ((t_fampl1 != 0) && (t_ffreq1 == 0))
                {
                    MessageBox.Show("Force amplitude is given but frequency is not given at Node 1.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }

                if ((t_fampl2 != 0) && (t_ffreq2 == 0))
                {
                    MessageBox.Show("Force amplitude is given but frequency is not given at Node 2.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }

            }


            // If all validations pass, store the values
            idispl1 = t_idispl1;
            idispl2 = t_idispl2;

            ivelo1 = t_ivelo1;
            ivelo2 = t_ivelo2;

            fampl1 = t_fampl1;
            fampl2 = t_fampl2;

            ffreq1 = t_ffreq1;
            ffreq2 = t_ffreq2;

            // Analysis solver settings
            a_starttime = t_starttime;
            a_endtime = t_endtime;
            a_timeinterval = t_timeinterval;

            return true;
        }

    }
}
