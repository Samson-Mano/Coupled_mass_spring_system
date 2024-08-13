using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.WindowsForms;

namespace Coupled_mass_spring_system
{
    public partial class plot_form : Form
    {

        private TableLayoutPanel tableLayoutPanel; // Store the reference to the TableLayoutPanel

        public plot_form(TableLayoutPanel tableLayoutPanel)
        {
            InitializeComponent();

            // Assign the passed TableLayoutPanel to the private member
            this.tableLayoutPanel = tableLayoutPanel;

            // Create a Panel to hold the TableLayoutPanel and add padding
            var containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 28, 0, 0) // Add padding to the top
            };

            containerPanel.Controls.Add(tableLayoutPanel);

            this.Controls.Add(containerPanel);
        }

        private void savePNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Bitmap with a transparent background
            using (Bitmap bitmap = new Bitmap(tableLayoutPanel.Width, tableLayoutPanel.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                // Set the entire bitmap to be transparent
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Transparent);
                }

                // Draw the tableLayoutPanel onto the bitmap
                tableLayoutPanel.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

                // Save the bitmap as a PNG with a transparent background
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Files|*.png";
                    saveFileDialog.Title = "Save as PNG";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }
    }
}
