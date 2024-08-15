using Coupled_mass_spring_system.solver;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coupled_mass_spring_system
{
    public partial class fResp_form : Form
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

        // Analysis force data
        private double fampl1 = 0.0;
        private double fampl2 = 0.0;

        private double ffreq1 = 0.0;
        private double ffreq2 = 0.0;

        // Frequency range data
        private double freqstart = 0.0;
        private double freqend = 0.0;
        private double freqinterval = 0.0;


        // Main solver variable
        frequency_resp_solver solver;

        // Plot view window
        plot_form plt_form;


        public fResp_form()
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

            // Set the default values
            set_defaults();

            // Reset the analysis
            is_analysis_complete = false;

            label_IsSolveComplete.Text = "Solve not complete!";
            label_IsSolveComplete.ForeColor = Color.Red;
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            // Check whether the inputs in the text boxes are valid
            if (Is_InputDatas_valid() != true)
            {
                return;
            }

             // save the valid inputs to the system settings
            save_inputs();

            // Input datas are valid proceed with the solve
            // Define the number of DOF
            int num_DOF = 2;

            // Initialize the solver
            solver = new frequency_resp_solver(num_DOF);

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

            // Define the force data
            double[] forceAmplitudes = { fampl1, fampl2 };
            double[] forceFrequencies = { ffreq1, ffreq2 };
            solver.SetForceData(forceAmplitudes, forceFrequencies);

            // Set analysis settings
            solver.SetAnalysisSettings(checkBox_autoselectfreq.Checked, freqstart, freqend, freqinterval);
  
            // Solve the system
            solver.Solve();

            // Set the analysis complete
            this.is_analysis_complete = true;

            label_IsSolveComplete.Text = "Solve complete!";
            label_IsSolveComplete.ForeColor = Color.Green;

        }

        private void checkBox_autoselectfreq_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_autoselectfreq.Checked == true)
            {
                // Frequency range labels and text box disabled
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false; 

                textBox_freqstart.Enabled = false;
                textBox_freqend.Enabled = false;    
                textBox_freqinterval.Enabled = false;
            }
            else
            {
                // Frequency range labels and text box enabled
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;

                textBox_freqstart.Enabled = true;
                textBox_freqend.Enabled = true;
                textBox_freqinterval.Enabled = true;

            }
        }

        private void button_showresp_Click(object sender, EventArgs e)
        {
            // Check whether the analysis is complete
            if (is_analysis_complete == false)
            {
                return;
            }

            // List to store datas based on the selected options
            List<Tuple<string, List<double>>> Displacement_datas = new List<Tuple<string, List<double>>>();
            List<Tuple<string, List<double>>> Velocity_datas = new List<Tuple<string, List<double>>>();
            List<Tuple<string, List<double>>> Acceleration_datas = new List<Tuple<string, List<double>>>();

            bool is_Displacement_selected = false;
            bool is_Velocity_selected = false;
            bool is_Acceleration_selected = false;

            // Populate data lists based on selected options
            foreach (int index in checkedListBox_respType.CheckedIndices)
            {
                switch (index)
                {
                    case 0:
                        Displacement_datas.Add(new Tuple<string, List<double>>("Displacement at Node 1", solver.GetDisplacement(0)));
                        is_Displacement_selected = true;
                        break;
                    case 1:
                        Velocity_datas.Add(new Tuple<string, List<double>>("Velocity at Node 1", solver.GetVelocity(0)));
                        is_Velocity_selected = true;
                        break;
                    case 2:
                        Acceleration_datas.Add(new Tuple<string, List<double>>("Acceleration at Node 1", solver.GetAcceleration(0)));
                        is_Acceleration_selected = true;
                        break;
                    case 3:
                        Displacement_datas.Add(new Tuple<string, List<double>>("Displacement at Node 2", solver.GetDisplacement(1)));
                        is_Displacement_selected = true;
                        break;
                    case 4:
                        Velocity_datas.Add(new Tuple<string, List<double>>("Velocity at Node 2", solver.GetVelocity(1)));
                        is_Velocity_selected = true;
                        break;
                    case 5:
                        Acceleration_datas.Add(new Tuple<string, List<double>>("Acceleration at Node 2", solver.GetAcceleration(1)));
                        is_Acceleration_selected = true;
                        break;
                }
            }

            if ((Displacement_datas.Count + Velocity_datas.Count + Acceleration_datas.Count) == 0)
            {
                MessageBox.Show("No options selected for plotting.");
                return;
            }


            // Get the frequency data
            List<double> freq_data = solver.GetFrequencydata();

            // Create a TableLayoutPanel to arrange the PlotViews
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 0, // Set this to the number of plots you will add
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BorderStyle = BorderStyle.None
            };

            // Count the number of plots to be added
            int numPlots = (is_Displacement_selected ? 1 : 0) +
                            (is_Velocity_selected ? 1 : 0) +
                            (is_Acceleration_selected ? 1 : 0);

            tableLayoutPanel.RowCount = numPlots;

            // Add uniform row styles
            for (int i = 0; i < numPlots; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / numPlots)); // Split space uniformly
            }

            // Initialize row index
            int rowIndex = 0;

            // Add subplots to the PlotModels
            if (is_Displacement_selected)
            {
                // Create and configure PlotModels
                var displacementPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None
                };
                // Displacement Vs. Time
                AddSinglePlot(new PlotModel(),
                    freq_data, "Displacement", Displacement_datas, displacementPanel);

                tableLayoutPanel.Controls.Add(displacementPanel, 0, rowIndex);
                rowIndex++;
            }

            if (is_Velocity_selected)
            {
                // Create and configure PlotModels
                var velocityPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None
                };
                // Velocity Vs. Time
                AddSinglePlot(new PlotModel(),
                    freq_data, "Velocity", Velocity_datas, velocityPanel);

                tableLayoutPanel.Controls.Add(velocityPanel, 0, rowIndex);
                rowIndex++;
            }

            if (is_Acceleration_selected)
            {
                // Create and configure PlotModels
                var accelerationPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None
                };
                // Acceleration Vs. Time
                AddSinglePlot(new PlotModel(),
                    freq_data, "Acceleration", Acceleration_datas, accelerationPanel);

                tableLayoutPanel.Controls.Add(accelerationPanel, 0, rowIndex);
                rowIndex++;
            }



            plt_form = new plot_form(tableLayoutPanel);

            plt_form.Show();
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            // Export the data to text file
            // Check whether the analysis is complete
            if (is_analysis_complete == false)
            {
                return;
            }

            // List to store datas based on the selected options
            List<Tuple<string, List<double>>> Displacement_datas = new List<Tuple<string, List<double>>>();
            List<Tuple<string, List<double>>> Velocity_datas = new List<Tuple<string, List<double>>>();
            List<Tuple<string, List<double>>> Acceleration_datas = new List<Tuple<string, List<double>>>();

            bool is_Displacement_selected = false;
            bool is_Velocity_selected = false;
            bool is_Acceleration_selected = false;

            // Populate data lists based on selected options
            foreach (int index in checkedListBox_respType.CheckedIndices)
            {
                switch (index)
                {
                    case 0:
                        Displacement_datas.Add(new Tuple<string, List<double>>("Displacement at Node 1", solver.GetDisplacement(0)));
                        is_Displacement_selected = true;
                        break;
                    case 1:
                        Velocity_datas.Add(new Tuple<string, List<double>>("Velocity at Node 1", solver.GetVelocity(0)));
                        is_Velocity_selected = true;
                        break;
                    case 2:
                        Acceleration_datas.Add(new Tuple<string, List<double>>("Acceleration at Node 1", solver.GetAcceleration(0)));
                        is_Acceleration_selected = true;
                        break;
                    case 3:
                        Displacement_datas.Add(new Tuple<string, List<double>>("Displacement at Node 2", solver.GetDisplacement(1)));
                        is_Displacement_selected = true;
                        break;
                    case 4:
                        Velocity_datas.Add(new Tuple<string, List<double>>("Velocity at Node 2", solver.GetVelocity(1)));
                        is_Velocity_selected = true;
                        break;
                    case 5:
                        Acceleration_datas.Add(new Tuple<string, List<double>>("Acceleration at Node 2", solver.GetAcceleration(1)));
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
            List<double> freq_data = solver.GetFrequencydata();

            // Add subplots to the PlotModels
            if (is_Displacement_selected)
            {
                // Displacement Vs. Time
                ExportData("Displacement_response", freq_data, Displacement_datas);
            }

            if (is_Velocity_selected)
            {
                // Velocity Vs. Time
                ExportData("Velocity_response", freq_data, Velocity_datas);
            }

            if (is_Acceleration_selected)
            {
                // Acceleration Vs. Time
                ExportData("Acceleration_response", freq_data, Acceleration_datas);
            }

        }



        private void AddSinglePlot(PlotModel model, List<double> freq_data, string yLabel,
            List<Tuple<string, List<double>>> data, Panel panel)
        {

            // Set the background to transparent
            model.Background = OxyColors.Transparent;
            model.PlotAreaBackground = OxyColors.Transparent;

            // Create and configure the legend
            var legend = new Legend
            {
                // LegendTitle = "Response Vs Time",
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.TopRight,
                LegendBackground = OxyColors.Transparent,
                LegendBorder = OxyColors.Black,
            };

            // Add the legend
            model.Legends.Add(legend);

            // Create and configure the X axis
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Frequency (Hz)", // Label for X axis
                IsZoomEnabled = true, // Optional: allow zooming
                IsPanEnabled = true,  // Optional: allow panning
            };

            // Create and configure the Y axis
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = yLabel, // Label for Y axis, using yLabel passed to the method
                IsZoomEnabled = true, // Optional: allow zooming
                IsPanEnabled = true,  // Optional: allow panning
            };

            // Add the axes to the model
            model.Axes.Add(xAxis);
            model.Axes.Add(yAxis);

            for (int j = 0; j < data.Count; j++)
            {
                // Randomly select a color from the rainbowColors list
                //var color = rainbowColors[random.Next(rainbowColors.Count)];

                var series = new LineSeries
                {
                    // series name is data[j].Item1;
                    Title = data[j].Item1,
                    //Color = color // Set the color for each series
                };

                for (int i = 0; i < freq_data.Count; i++)
                {
                    series.Points.Add(new DataPoint(freq_data[i], data[j].Item2[i])); // Assuming data contains 1D arrays
                }

                model.Series.Add(series);

            }


            // Create a PlotView and add it to the panel
            var plotView = new OxyPlot.WindowsForms.PlotView
            {
                Model = model,
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(plotView);
        }


        private void ExportData(string label, List<double> freq_data, List<Tuple<string, List<double>>> data)
        {
            // Show save file dialog to get the file path
            string filePath = GetSaveFilePath(label);
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            // Write data to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header
                var headerBuilder = new StringBuilder("Frequency");
                foreach (var tuple in data)
                {
                    headerBuilder.Append(", ").Append(tuple.Item1);
                }
                writer.WriteLine(headerBuilder.ToString());

                // Write data points
                for (int i = 0; i < freq_data.Count; i++)
                {
                    var lineBuilder = new StringBuilder(freq_data[i].ToString());
                    foreach (var tuple in data)
                    {
                        lineBuilder.Append(", ").Append(tuple.Item2[i].ToString());
                    }
                    writer.WriteLine(lineBuilder.ToString());
                }
            }
        }


        private string GetSaveFilePath(string title)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "TXT Files|*.txt";
                saveFileDialog.Title = "Save Response";

                // Set a default file name
                saveFileDialog.FileName = $"{title}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }



        private bool Is_InputDatas_valid()
        {
            // Function to check the values of input data
            // Parse and validate Force amplitude data
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

            if (t_fampl1 == 0 && t_fampl2 == 0)
            {
                MessageBox.Show("Force amplitude at both nodes cannot be zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Parse and validate Force frequency data
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

            if (t_ffreq1 == 0 && t_ffreq2 == 0)
            {
                MessageBox.Show("Force frequency factors at both nodes cannot be zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // Check whether the auto create frequency range is checked or not
            if (checkBox_autoselectfreq.Checked == false)
            {

                // Parse and validate Frequency range data
                if (!double.TryParse(textBox_freqstart.Text, out double t_freqstart) || t_freqstart < 0)
                {
                    MessageBox.Show("Frequency start value must be zero or a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!double.TryParse(textBox_freqend.Text, out double t_freqend) || t_freqend < t_freqstart)
                {
                    MessageBox.Show("Frequency end value must be a positive number and greater than frequency start value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                if (!double.TryParse(textBox_freqinterval.Text, out double t_freqinterval) || t_freqinterval > (t_freqend - t_freqstart))
                {
                    MessageBox.Show("Frequency interval must be a positive number and less than the difference between frequency end value and frequency start value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                // Frequency range data
                freqstart = t_freqstart;
                freqend = t_freqend;
                freqinterval = t_freqinterval;
            }
            else
            {
                // Auto create frequency range based on the natural frequencies
                freqstart = 0.0;
                freqend = 0.0;
                freqinterval = 0.0;
            }

            // If all validations pass, store the values
            fampl1 = t_fampl1;
            fampl2 = t_fampl2;

            ffreq1 = t_ffreq1;
            ffreq2 = t_ffreq2;


            return true;
        }


        private void set_defaults()
        {
            // Force amplitudes
            textBox_fampl1.Text = Properties.Settings.Default.sett_fr_fampl1.ToString();
            textBox_fampl2.Text = Properties.Settings.Default.sett_fr_fampl2.ToString();

            // Force frequencies
            textBox_ffreq1.Text = Properties.Settings.Default.sett_fr_ffreq1.ToString();
            textBox_ffreq2.Text = Properties.Settings.Default.sett_fr_ffreq2.ToString();

            // Analysis settings
            textBox_freqstart.Text = Properties.Settings.Default.sett_fr_fstart.ToString();
            textBox_freqend.Text = Properties.Settings.Default.sett_fr_fend.ToString();
            textBox_freqinterval.Text = Properties.Settings.Default.sett_fr_finterval.ToString();

        }

        private void save_inputs()
        {
            // Force amplitudes
            Properties.Settings.Default.sett_fr_fampl1 = fampl1;
            Properties.Settings.Default.sett_fr_fampl2 = fampl2;

            // Force frequencies
            Properties.Settings.Default.sett_fr_ffreq1 = ffreq1;
            Properties.Settings.Default.sett_fr_ffreq2 = ffreq2;

            if (checkBox_autoselectfreq.Checked == false)
            {
                // Analysis settings
                Properties.Settings.Default.sett_fr_fstart = freqstart;
                Properties.Settings.Default.sett_fr_fend = freqend;
                Properties.Settings.Default.sett_fr_finterval = freqinterval;
            }

            Properties.Settings.Default.Save();

        }


    }
}
