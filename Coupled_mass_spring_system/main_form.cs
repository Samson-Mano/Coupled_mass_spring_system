using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Coupled_mass_spring_system
{
    public partial class main_form : Form
    {
        tResp_form tResp_Form1;
        fResp_form fResp_Form1;

        // Store the variables
        private double mass_m1 = 0.0;
        private double mass_m2 = 0.0;

        private double stiff_k1 = 0.0;
        private double stiff_k2 = 0.0;
        private double stiff_k3 = 0.0;

        private double zeta1 = 0.0;
        private double zeta2 = 0.0;


        public main_form()
        {
            InitializeComponent();
        }

        private void button_timeVresp_Click(object sender, EventArgs e)
        {
            // Time vs Response solver creation
            if (Is_InputDatas_valid())
            {
                // Check if tResp_Form1 is null or disposed
                if (tResp_Form1 == null || tResp_Form1.IsDisposed)
                {
                    tResp_Form1 = new tResp_form();
                }

                // Update the spring model data and show the form
                tResp_Form1.update_springmodel_data(mass_m1, mass_m2, stiff_k1, stiff_k2, stiff_k3, zeta1, zeta2);
                tResp_Form1.Show();
                tResp_Form1.BringToFront(); // Bring the form to the front if it is already open
            }

        }


        private void button_freqVresp_Click(object sender, EventArgs e)
        {
            // Frequency vs Response solver creation
            if (Is_InputDatas_valid())
            {
                // Check if fResp_Form1 is null or disposed
                if (fResp_Form1 == null || fResp_Form1.IsDisposed)
                {
                    fResp_Form1 = new fResp_form();
                }

                // Update the spring model data and show the form
                fResp_Form1.update_springmodel_data(mass_m1, mass_m2, stiff_k1, stiff_k2, stiff_k3, zeta1, zeta2);
                fResp_Form1.Show();
                fResp_Form1.BringToFront(); // Bring the form to the front if it is already open
            }

        }

        private bool Is_InputDatas_valid()
        {
            // Function to check the values of input data
            // Parse and validate Mass data
            if (!double.TryParse(textBox_massm1.Text, out double t_mass_m1) || t_mass_m1 <= 0)
            {
                MessageBox.Show("Mass m1 must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_massm2.Text, out double t_mass_m2) || t_mass_m2 <= 0)
            {
                MessageBox.Show("Mass m2 must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Parse and validate Stiffness data
            if (!double.TryParse(textBox_stiffk1.Text, out double t_stiff_k1) || t_stiff_k1 < 0)
            {
                MessageBox.Show("Stiffness k1 must be a non-negative number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_stiffk2.Text, out double t_stiff_k2) || t_stiff_k2 <= 0)
            {
                MessageBox.Show("Stiffness k2 must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_stiffk3.Text, out double t_stiff_k3) || t_stiff_k3 < 0)
            {
                MessageBox.Show("Stiffness k3 must be a non-negative number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Parse and validate Modal damping ratios data
            if (!double.TryParse(textBox_zeta1.Text, out double t_zeta1) || t_zeta1 <= 0 || t_zeta1 >= 1)
            {
                MessageBox.Show("Zeta1 must be between 0 and 1.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(textBox_zeta2.Text, out double t_zeta2) || t_zeta2 <= 0 || t_zeta2 >= 1)
            {
                MessageBox.Show("Zeta2 must be between 0 and 1.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // If all validations pass, store the values
            mass_m1 = t_mass_m1;
            mass_m2 = t_mass_m2;
            stiff_k1 = t_stiff_k1;
            stiff_k2 = t_stiff_k2;
            stiff_k3 = t_stiff_k3;
            zeta1 = t_zeta1;
            zeta2 = t_zeta2;

            return true;
      }

    }
}
