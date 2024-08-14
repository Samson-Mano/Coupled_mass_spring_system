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
            this.textBox_massm2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_massm1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_stiffk3 = new System.Windows.Forms.TextBox();
            this.textBox_stiffk2 = new System.Windows.Forms.TextBox();
            this.textBox_stiffk1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_zeta2 = new System.Windows.Forms.TextBox();
            this.textBox_zeta1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_timeVresp = new System.Windows.Forms.Button();
            this.button_freqVresp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(262, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mass :";
            // 
            // textBox_massm2
            // 
            this.textBox_massm2.Location = new System.Drawing.Point(120, 88);
            this.textBox_massm2.Name = "textBox_massm2";
            this.textBox_massm2.Size = new System.Drawing.Size(124, 31);
            this.textBox_massm2.TabIndex = 3;
            this.textBox_massm2.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mass m2 = ";
            // 
            // textBox_massm1
            // 
            this.textBox_massm1.Location = new System.Drawing.Point(120, 44);
            this.textBox_massm1.Name = "textBox_massm1";
            this.textBox_massm1.Size = new System.Drawing.Size(124, 31);
            this.textBox_massm1.TabIndex = 1;
            this.textBox_massm1.Text = "200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mass m1 = ";
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
            this.groupBox2.Size = new System.Drawing.Size(296, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stiffness :";
            // 
            // textBox_stiffk3
            // 
            this.textBox_stiffk3.Location = new System.Drawing.Point(152, 134);
            this.textBox_stiffk3.Name = "textBox_stiffk3";
            this.textBox_stiffk3.Size = new System.Drawing.Size(124, 31);
            this.textBox_stiffk3.TabIndex = 5;
            this.textBox_stiffk3.Text = "0.0";
            // 
            // textBox_stiffk2
            // 
            this.textBox_stiffk2.Location = new System.Drawing.Point(152, 88);
            this.textBox_stiffk2.Name = "textBox_stiffk2";
            this.textBox_stiffk2.Size = new System.Drawing.Size(124, 31);
            this.textBox_stiffk2.TabIndex = 4;
            this.textBox_stiffk2.Text = "1800";
            // 
            // textBox_stiffk1
            // 
            this.textBox_stiffk1.Location = new System.Drawing.Point(152, 44);
            this.textBox_stiffk1.Name = "textBox_stiffk1";
            this.textBox_stiffk1.Size = new System.Drawing.Size(124, 31);
            this.textBox_stiffk1.TabIndex = 3;
            this.textBox_stiffk1.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Stiffness k3 = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stiffness k2 = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stiffness k1 = ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_zeta2);
            this.groupBox3.Controls.Add(this.textBox_zeta1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(195, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 153);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modal Damping Ratios :";
            // 
            // textBox_zeta2
            // 
            this.textBox_zeta2.Location = new System.Drawing.Point(235, 85);
            this.textBox_zeta2.Name = "textBox_zeta2";
            this.textBox_zeta2.Size = new System.Drawing.Size(124, 31);
            this.textBox_zeta2.TabIndex = 3;
            this.textBox_zeta2.Text = "0.015";
            // 
            // textBox_zeta1
            // 
            this.textBox_zeta1.Location = new System.Drawing.Point(235, 41);
            this.textBox_zeta1.Name = "textBox_zeta1";
            this.textBox_zeta1.Size = new System.Drawing.Size(124, 31);
            this.textBox_zeta1.TabIndex = 2;
            this.textBox_zeta1.Text = "0.015";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "mode 2 Damping ratio = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "mode 1 Damping ratio = ";
            // 
            // button_timeVresp
            // 
            this.button_timeVresp.Location = new System.Drawing.Point(207, 386);
            this.button_timeVresp.Name = "button_timeVresp";
            this.button_timeVresp.Size = new System.Drawing.Size(264, 88);
            this.button_timeVresp.TabIndex = 6;
            this.button_timeVresp.Text = "Time Vs. Response";
            this.button_timeVresp.UseVisualStyleBackColor = true;
            this.button_timeVresp.Click += new System.EventHandler(this.button_timeVresp_Click);
            // 
            // button_freqVresp
            // 
            this.button_freqVresp.Location = new System.Drawing.Point(484, 386);
            this.button_freqVresp.Name = "button_freqVresp";
            this.button_freqVresp.Size = new System.Drawing.Size(264, 88);
            this.button_freqVresp.TabIndex = 7;
            this.button_freqVresp.Text = "Frequency Vs. Response";
            this.button_freqVresp.UseVisualStyleBackColor = true;
            this.button_freqVresp.Click += new System.EventHandler(this.button_freqVresp_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.button_freqVresp);
            this.Controls.Add(this.button_timeVresp);
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
        private System.Windows.Forms.Button button_timeVresp;
        private System.Windows.Forms.Button button_freqVresp;
    }
}

