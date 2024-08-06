namespace Coupled_mass_spring_system
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_massm1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_massm2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_stiffk1 = new System.Windows.Forms.TextBox();
            this.textBox_stiffk2 = new System.Windows.Forms.TextBox();
            this.textBox_stiffk3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_zeta1 = new System.Windows.Forms.TextBox();
            this.textBox_zeta2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_forceampl1 = new System.Windows.Forms.TextBox();
            this.textBox_forceampl2 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_forcefreq1 = new System.Windows.Forms.TextBox();
            this.textBox_forcefreq2 = new System.Windows.Forms.TextBox();
            this.button_timeVresp = new System.Windows.Forms.Button();
            this.button_freqVresp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Coupled_mass_spring_system.Properties.Resources.two_mass_system_pic;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 528);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_massm2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_massm1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(195, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(262, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mass :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mass m1 = ";
            // 
            // textBox_massm1
            // 
            this.textBox_massm1.Location = new System.Drawing.Point(120, 39);
            this.textBox_massm1.Name = "textBox_massm1";
            this.textBox_massm1.Size = new System.Drawing.Size(124, 31);
            this.textBox_massm1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mass m2 = ";
            // 
            // textBox_massm2
            // 
            this.textBox_massm2.Location = new System.Drawing.Point(120, 83);
            this.textBox_massm2.Name = "textBox_massm2";
            this.textBox_massm2.Size = new System.Drawing.Size(124, 31);
            this.textBox_massm2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_stiffk3);
            this.groupBox2.Controls.Add(this.textBox_stiffk2);
            this.groupBox2.Controls.Add(this.textBox_stiffk1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(472, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 175);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stiffness :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stiffness k1 = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stiffness k2 = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Stiffness k3 = ";
            // 
            // textBox_stiffk1
            // 
            this.textBox_stiffk1.Location = new System.Drawing.Point(150, 34);
            this.textBox_stiffk1.Name = "textBox_stiffk1";
            this.textBox_stiffk1.Size = new System.Drawing.Size(124, 31);
            this.textBox_stiffk1.TabIndex = 3;
            // 
            // textBox_stiffk2
            // 
            this.textBox_stiffk2.Location = new System.Drawing.Point(150, 78);
            this.textBox_stiffk2.Name = "textBox_stiffk2";
            this.textBox_stiffk2.Size = new System.Drawing.Size(124, 31);
            this.textBox_stiffk2.TabIndex = 4;
            // 
            // textBox_stiffk3
            // 
            this.textBox_stiffk3.Location = new System.Drawing.Point(150, 124);
            this.textBox_stiffk3.Name = "textBox_stiffk3";
            this.textBox_stiffk3.Size = new System.Drawing.Size(124, 31);
            this.textBox_stiffk3.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_zeta2);
            this.groupBox3.Controls.Add(this.textBox_zeta1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(195, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 126);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modal Damping Ratios :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "mode 1 Damping ratio = ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "mode 2 Damping ratio = ";
            // 
            // textBox_zeta1
            // 
            this.textBox_zeta1.Location = new System.Drawing.Point(235, 33);
            this.textBox_zeta1.Name = "textBox_zeta1";
            this.textBox_zeta1.Size = new System.Drawing.Size(124, 31);
            this.textBox_zeta1.TabIndex = 2;
            // 
            // textBox_zeta2
            // 
            this.textBox_zeta2.Location = new System.Drawing.Point(235, 77);
            this.textBox_zeta2.Name = "textBox_zeta2";
            this.textBox_zeta2.Size = new System.Drawing.Size(124, 31);
            this.textBox_zeta2.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_forceampl2);
            this.groupBox4.Controls.Add(this.textBox_forceampl1);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(195, 325);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 128);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Force Amplitude :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Force p1 = ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "Force p2 = ";
            // 
            // textBox_forceampl1
            // 
            this.textBox_forceampl1.Location = new System.Drawing.Point(120, 33);
            this.textBox_forceampl1.Name = "textBox_forceampl1";
            this.textBox_forceampl1.Size = new System.Drawing.Size(124, 31);
            this.textBox_forceampl1.TabIndex = 2;
            // 
            // textBox_forceampl2
            // 
            this.textBox_forceampl2.Location = new System.Drawing.Point(120, 76);
            this.textBox_forceampl2.Name = "textBox_forceampl2";
            this.textBox_forceampl2.Size = new System.Drawing.Size(124, 31);
            this.textBox_forceampl2.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_forcefreq2);
            this.groupBox5.Controls.Add(this.textBox_forcefreq1);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(463, 325);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(304, 127);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Force Frequency :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Frequency f1 = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "Frequency f2 = ";
            // 
            // textBox_forcefreq1
            // 
            this.textBox_forcefreq1.Location = new System.Drawing.Point(159, 33);
            this.textBox_forcefreq1.Name = "textBox_forcefreq1";
            this.textBox_forcefreq1.Size = new System.Drawing.Size(124, 31);
            this.textBox_forcefreq1.TabIndex = 2;
            // 
            // textBox_forcefreq2
            // 
            this.textBox_forcefreq2.Location = new System.Drawing.Point(159, 76);
            this.textBox_forcefreq2.Name = "textBox_forcefreq2";
            this.textBox_forcefreq2.Size = new System.Drawing.Size(124, 31);
            this.textBox_forcefreq2.TabIndex = 3;
            // 
            // button_timeVresp
            // 
            this.button_timeVresp.Location = new System.Drawing.Point(221, 470);
            this.button_timeVresp.Name = "button_timeVresp";
            this.button_timeVresp.Size = new System.Drawing.Size(218, 59);
            this.button_timeVresp.TabIndex = 6;
            this.button_timeVresp.Text = "Time Vs. Response";
            this.button_timeVresp.UseVisualStyleBackColor = true;
            // 
            // button_freqVresp
            // 
            this.button_freqVresp.Location = new System.Drawing.Point(491, 470);
            this.button_freqVresp.Name = "button_freqVresp";
            this.button_freqVresp.Size = new System.Drawing.Size(218, 59);
            this.button_freqVresp.TabIndex = 7;
            this.button_freqVresp.Text = "Frequency Vs. Response";
            this.button_freqVresp.UseVisualStyleBackColor = true;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.button_freqVresp);
            this.Controls.Add(this.button_timeVresp);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "main_form";
            this.Text = "Coupled Mass Spring System ----- Developed by Samson Mano <saminnx@gmail.com>";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_massm2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_massm1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_stiffk3;
        private System.Windows.Forms.TextBox textBox_stiffk2;
        private System.Windows.Forms.TextBox textBox_stiffk1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_zeta2;
        private System.Windows.Forms.TextBox textBox_zeta1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_forceampl2;
        private System.Windows.Forms.TextBox textBox_forceampl1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_forcefreq2;
        private System.Windows.Forms.TextBox textBox_forcefreq1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_timeVresp;
        private System.Windows.Forms.Button button_freqVresp;
    }
}

