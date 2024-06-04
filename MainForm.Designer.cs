namespace KollisionsKontroll
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.txtLatIso = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chKollision = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVRTiso = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArmVrtSin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtArmVrtDx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArmLatSin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArmLatDx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpArmDx = new System.Windows.Forms.GroupBox();
            this.lblArmDx = new System.Windows.Forms.Label();
            this.grpArmSin = new System.Windows.Forms.GroupBox();
            this.lblArmSin = new System.Windows.Forms.Label();
            this.grpBord = new System.Windows.Forms.GroupBox();
            this.lblBord = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chKollision)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpArmDx.SuspendLayout();
            this.grpArmSin.SuspendLayout();
            this.grpBord.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLatIso
            // 
            this.txtLatIso.Location = new System.Drawing.Point(65, 24);
            this.txtLatIso.Name = "txtLatIso";
            this.txtLatIso.Size = new System.Drawing.Size(46, 20);
            this.txtLatIso.TabIndex = 0;
            this.txtLatIso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLatIso_KeyDown);
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(25, 449);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 32);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Kör";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(216, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 479);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Krockcirkel";
            // 
            // chKollision
            // 
            this.chKollision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chKollision.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chKollision.Legends.Add(legend1);
            this.chKollision.Location = new System.Drawing.Point(228, 29);
            this.chKollision.Name = "chKollision";
            this.chKollision.Size = new System.Drawing.Size(619, 448);
            this.chKollision.TabIndex = 12;
            this.chKollision.Text = "chart1";
            this.chKollision.PrePaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chKollision_PrePaint);
            this.chKollision.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chKollision_MouseClick);
            this.chKollision.Resize += new System.EventHandler(this.chKollision_Resize);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "LAT [cm]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "VRT [cm]";
            // 
            // txtVRTiso
            // 
            this.txtVRTiso.Location = new System.Drawing.Point(65, 47);
            this.txtVRTiso.Name = "txtVRTiso";
            this.txtVRTiso.Size = new System.Drawing.Size(46, 20);
            this.txtVRTiso.TabIndex = 5;
            this.txtVRTiso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVRTiso_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLatIso);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtVRTiso);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 82);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Isocenter position";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtArmVrtSin);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtArmVrtDx);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtArmLatSin);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtArmLatDx);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 160);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Armarnas position ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Vänster arm";
            // 
            // txtArmVrtSin
            // 
            this.txtArmVrtSin.Location = new System.Drawing.Point(94, 129);
            this.txtArmVrtSin.Name = "txtArmVrtSin";
            this.txtArmVrtSin.Size = new System.Drawing.Size(46, 20);
            this.txtArmVrtSin.TabIndex = 16;
            this.txtArmVrtSin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArmVrtSin_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Höger arm";
            // 
            // txtArmVrtDx
            // 
            this.txtArmVrtDx.Location = new System.Drawing.Point(94, 107);
            this.txtArmVrtDx.Name = "txtArmVrtDx";
            this.txtArmVrtDx.Size = new System.Drawing.Size(46, 20);
            this.txtArmVrtDx.TabIndex = 14;
            this.txtArmVrtDx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArmVrtDx_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Vänster arm";
            // 
            // txtArmLatSin
            // 
            this.txtArmLatSin.Location = new System.Drawing.Point(94, 61);
            this.txtArmLatSin.Name = "txtArmLatSin";
            this.txtArmLatSin.Size = new System.Drawing.Size(46, 20);
            this.txtArmLatSin.TabIndex = 12;
            this.txtArmLatSin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArmLatSin_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Höger arm";
            // 
            // txtArmLatDx
            // 
            this.txtArmLatDx.Location = new System.Drawing.Point(94, 39);
            this.txtArmLatDx.Name = "txtArmLatDx";
            this.txtArmLatDx.Size = new System.Drawing.Size(46, 20);
            this.txtArmLatDx.TabIndex = 7;
            this.txtArmLatDx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArmLatDx_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "VRT [cm]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "LAT [cm]";
            // 
            // grpArmDx
            // 
            this.grpArmDx.Controls.Add(this.lblArmDx);
            this.grpArmDx.Location = new System.Drawing.Point(12, 266);
            this.grpArmDx.Name = "grpArmDx";
            this.grpArmDx.Size = new System.Drawing.Size(198, 55);
            this.grpArmDx.TabIndex = 9;
            this.grpArmDx.TabStop = false;
            this.grpArmDx.Text = "Höger arm";
            // 
            // lblArmDx
            // 
            this.lblArmDx.AutoSize = true;
            this.lblArmDx.Location = new System.Drawing.Point(6, 25);
            this.lblArmDx.Name = "lblArmDx";
            this.lblArmDx.Size = new System.Drawing.Size(0, 13);
            this.lblArmDx.TabIndex = 0;
            // 
            // grpArmSin
            // 
            this.grpArmSin.Controls.Add(this.lblArmSin);
            this.grpArmSin.Location = new System.Drawing.Point(12, 327);
            this.grpArmSin.Name = "grpArmSin";
            this.grpArmSin.Size = new System.Drawing.Size(198, 55);
            this.grpArmSin.TabIndex = 10;
            this.grpArmSin.TabStop = false;
            this.grpArmSin.Text = "Vänster arm";
            // 
            // lblArmSin
            // 
            this.lblArmSin.AutoSize = true;
            this.lblArmSin.Location = new System.Drawing.Point(6, 27);
            this.lblArmSin.Name = "lblArmSin";
            this.lblArmSin.Size = new System.Drawing.Size(0, 13);
            this.lblArmSin.TabIndex = 1;
            // 
            // grpBord
            // 
            this.grpBord.Controls.Add(this.lblBord);
            this.grpBord.Location = new System.Drawing.Point(12, 388);
            this.grpBord.Name = "grpBord";
            this.grpBord.Size = new System.Drawing.Size(198, 55);
            this.grpBord.TabIndex = 11;
            this.grpBord.TabStop = false;
            this.grpBord.Text = "Bord";
            // 
            // lblBord
            // 
            this.lblBord.AutoSize = true;
            this.lblBord.Location = new System.Drawing.Point(6, 25);
            this.lblBord.Name = "lblBord";
            this.lblBord.Size = new System.Drawing.Size(0, 13);
            this.lblBord.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(117, 449);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 32);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 506);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chKollision);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpBord);
            this.Controls.Add(this.grpArmSin);
            this.Controls.Add(this.grpArmDx);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExecute);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Kollisionskontroll (v 1.0 av Erik Fura)";
            ((System.ComponentModel.ISupportInitialize)(this.chKollision)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpArmDx.ResumeLayout(false);
            this.grpArmDx.PerformLayout();
            this.grpArmSin.ResumeLayout(false);
            this.grpArmSin.PerformLayout();
            this.grpBord.ResumeLayout(false);
            this.grpBord.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLatIso;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVRTiso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtArmVrtSin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtArmVrtDx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtArmLatSin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArmLatDx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpArmDx;
        private System.Windows.Forms.GroupBox grpArmSin;
        private System.Windows.Forms.GroupBox grpBord;
        private System.Windows.Forms.DataVisualization.Charting.Chart chKollision;
        private System.Windows.Forms.Label lblArmDx;
        private System.Windows.Forms.Label lblArmSin;
        private System.Windows.Forms.Label lblBord;
        private System.Windows.Forms.Button btnReset;
    }
}