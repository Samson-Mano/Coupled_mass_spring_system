using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if(t_fampl1 == 0  && t_fampl2 == 0)
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

            // Parse and validate Frequency range data
            if (!double.TryParse(textBox_freqstart.Text, out double t_freqstart) || t_freqstart < 0)
            {
                MessageBox.Show("Frequency start value must be zero or a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_freqend.Text, out double t_freqend) || t_freqend > t_freqstart)
            {
                MessageBox.Show("Frequency end value must be a positive number and greater than frequency start value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!double.TryParse(textBox_freqinterval.Text, out double t_freqinterval) || t_freqinterval < (t_freqend - t_freqstart))
            {
                MessageBox.Show("Frequency interval must be a positive number and less than the difference between frequency end value and frequency start value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // If all validations pass, store the values
            fampl1 = t_fampl1;
            fampl2 = t_fampl2;

            ffreq1 = t_ffreq1;
            ffreq2 = t_ffreq2;

            // Frequency range data
            freqstart = t_freqstart;
            freqend = t_freqend;
            freqinterval = t_freqinterval;

            return true;
        }
    }
}
