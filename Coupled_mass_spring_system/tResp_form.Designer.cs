namespace Coupled_mass_spring_system
{
    partial class tResp_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tResp_form));
            this.richTextBox_modeldata = new System.Windows.Forms.RichTextBox();
            this.button_showresp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ivelo2 = new System.Windows.Forms.TextBox();
            this.textBox_ivelo1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_idispl2 = new System.Windows.Forms.TextBox();
            this.textBox_idispl1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_ffreq2 = new System.Windows.Forms.TextBox();
            this.textBox_ffreq1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_fampl2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_fampl1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_timeinterval = new System.Windows.Forms.TextBox();
            this.textBox_endtime = new System.Windows.Forms.TextBox();
            this.textBox_starttime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_solve = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.checkedListBox_respType = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_modeldata
            // 
            this.richTextBox_modeldata.Location = new System.Drawing.Point(13, 13);
            this.richTextBox_modeldata.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_modeldata.Name = "richTextBox_modeldata";
            this.richTextBox_modeldata.Size = new System.Drawing.Size(406, 262);
            this.richTextBox_modeldata.TabIndex = 0;
            this.richTextBox_modeldata.Text = resources.GetString("richTextBox_modeldata.Text");
            // 
            // button_showresp
            // 
            this.button_showresp.Location = new System.Drawing.Point(644, 552);
            this.button_showresp.Name = "button_showresp";
            this.button_showresp.Size = new System.Drawing.Size(188, 55);
            this.button_showresp.TabIndex = 7;
            this.button_showresp.Text = "Show Response";
            this.button_showresp.UseVisualStyleBackColor = true;
            this.button_showresp.Click += new System.EventHandler(this.button_showresp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ivelo2);
            this.groupBox1.Controls.Add(this.textBox_ivelo1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_idispl2);
            this.groupBox1.Controls.Add(this.textBox_idispl1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(426, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 251);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial Conditions : ";
            // 
            // textBox_ivelo2
            // 
            this.textBox_ivelo2.Location = new System.Drawing.Point(268, 182);
            this.textBox_ivelo2.Name = "textBox_ivelo2";
            this.textBox_ivelo2.Size = new System.Drawing.Size(114, 31);
            this.textBox_ivelo2.TabIndex = 7;
            this.textBox_ivelo2.Text = "0.0";
            // 
            // textBox_ivelo1
            // 
            this.textBox_ivelo1.Location = new System.Drawing.Point(268, 143);
            this.textBox_ivelo1.Name = "textBox_ivelo1";
            this.textBox_ivelo1.Size = new System.Drawing.Size(114, 31);
            this.textBox_ivelo1.TabIndex = 6;
            this.textBox_ivelo1.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Initial velocity node 2 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Initial velocity node 1 : ";
            // 
            // textBox_idispl2
            // 
            this.textBox_idispl2.Location = new System.Drawing.Point(268, 73);
            this.textBox_idispl2.Name = "textBox_idispl2";
            this.textBox_idispl2.Size = new System.Drawing.Size(114, 31);
            this.textBox_idispl2.TabIndex = 3;
            this.textBox_idispl2.Text = "0.0";
            // 
            // textBox_idispl1
            // 
            this.textBox_idispl1.Location = new System.Drawing.Point(268, 33);
            this.textBox_idispl1.Name = "textBox_idispl1";
            this.textBox_idispl1.Size = new System.Drawing.Size(114, 31);
            this.textBox_idispl1.TabIndex = 2;
            this.textBox_idispl1.Text = "0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Initial displacement node 2 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Initial displacement node 1 : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_ffreq2);
            this.groupBox2.Controls.Add(this.textBox_ffreq1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_fampl2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_fampl1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(424, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 248);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Force data : ";
            // 
            // textBox_ffreq2
            // 
            this.textBox_ffreq2.Location = new System.Drawing.Point(270, 185);
            this.textBox_ffreq2.Name = "textBox_ffreq2";
            this.textBox_ffreq2.Size = new System.Drawing.Size(114, 31);
            this.textBox_ffreq2.TabIndex = 7;
            this.textBox_ffreq2.Text = "0.0";
            // 
            // textBox_ffreq1
            // 
            this.textBox_ffreq1.Location = new System.Drawing.Point(270, 144);
            this.textBox_ffreq1.Name = "textBox_ffreq1";
            this.textBox_ffreq1.Size = new System.Drawing.Size(114, 31);
            this.textBox_ffreq1.TabIndex = 6;
            this.textBox_ffreq1.Text = "2.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(223, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "Force frequency node 2 : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "Force frequency node 1 : ";
            // 
            // textBox_fampl2
            // 
            this.textBox_fampl2.Location = new System.Drawing.Point(270, 75);
            this.textBox_fampl2.Name = "textBox_fampl2";
            this.textBox_fampl2.Size = new System.Drawing.Size(114, 31);
            this.textBox_fampl2.TabIndex = 3;
            this.textBox_fampl2.Text = "0.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Force amplitude node 2 : ";
            // 
            // textBox_fampl1
            // 
            this.textBox_fampl1.Location = new System.Drawing.Point(270, 35);
            this.textBox_fampl1.Name = "textBox_fampl1";
            this.textBox_fampl1.Size = new System.Drawing.Size(114, 31);
            this.textBox_fampl1.TabIndex = 1;
            this.textBox_fampl1.Text = "1.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Force amplitude node 1 : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_timeinterval);
            this.groupBox3.Controls.Add(this.textBox_endtime);
            this.groupBox3.Controls.Add(this.textBox_starttime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(14, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 165);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Analysis settings : ";
            // 
            // textBox_timeinterval
            // 
            this.textBox_timeinterval.Location = new System.Drawing.Point(170, 118);
            this.textBox_timeinterval.Name = "textBox_timeinterval";
            this.textBox_timeinterval.Size = new System.Drawing.Size(114, 31);
            this.textBox_timeinterval.TabIndex = 12;
            this.textBox_timeinterval.Text = "0.01";
            // 
            // textBox_endtime
            // 
            this.textBox_endtime.Location = new System.Drawing.Point(170, 77);
            this.textBox_endtime.Name = "textBox_endtime";
            this.textBox_endtime.Size = new System.Drawing.Size(114, 31);
            this.textBox_endtime.TabIndex = 11;
            this.textBox_endtime.Text = "10.0";
            // 
            // textBox_starttime
            // 
            this.textBox_starttime.Location = new System.Drawing.Point(170, 37);
            this.textBox_starttime.Name = "textBox_starttime";
            this.textBox_starttime.Size = new System.Drawing.Size(114, 31);
            this.textBox_starttime.TabIndex = 10;
            this.textBox_starttime.Text = "0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Time interval : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "End time : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start time : ";
            // 
            // button_solve
            // 
            this.button_solve.Location = new System.Drawing.Point(436, 552);
            this.button_solve.Name = "button_solve";
            this.button_solve.Size = new System.Drawing.Size(156, 55);
            this.button_solve.TabIndex = 11;
            this.button_solve.Text = "Solve";
            this.button_solve.UseVisualStyleBackColor = true;
            this.button_solve.Click += new System.EventHandler(this.button_solve_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(603, 568);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 23);
            this.label12.TabIndex = 12;
            this.label12.Text = "-->";
            // 
            // checkedListBox_respType
            // 
            this.checkedListBox_respType.FormattingEnabled = true;
            this.checkedListBox_respType.Items.AddRange(new object[] {
            "Node 1 Displacement Response",
            "Node 1 Velocity Response",
            "Node 1 Acceleration Response",
            "Node 2 Displacement Response",
            "Node 2 Velocity Response",
            "Node 2 Acceleration Response"});
            this.checkedListBox_respType.Location = new System.Drawing.Point(14, 453);
            this.checkedListBox_respType.Name = "checkedListBox_respType";
            this.checkedListBox_respType.Size = new System.Drawing.Size(405, 186);
            this.checkedListBox_respType.TabIndex = 13;
            // 
            // tResp_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 653);
            this.Controls.Add(this.checkedListBox_respType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button_solve);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_showresp);
            this.Controls.Add(this.richTextBox_modeldata);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tResp_form";
            this.Text = "Time Vs. Response";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_modeldata;
        private System.Windows.Forms.Button button_showresp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_idispl2;
        private System.Windows.Forms.TextBox textBox_idispl1;
        private System.Windows.Forms.TextBox textBox_ivelo2;
        private System.Windows.Forms.TextBox textBox_ivelo1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_ffreq2;
        private System.Windows.Forms.TextBox textBox_ffreq1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_fampl2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_fampl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_timeinterval;
        private System.Windows.Forms.TextBox textBox_endtime;
        private System.Windows.Forms.TextBox textBox_starttime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_solve;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox checkedListBox_respType;
    }
}