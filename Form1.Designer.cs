﻿namespace WeatherAppUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Help_Btn = new System.Windows.Forms.Button();
            this.Indoors_Btn = new System.Windows.Forms.Button();
            this.OutDorr_Btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.List_Pnl = new System.Windows.Forms.Panel();
            this.Dryness_LBox = new System.Windows.Forms.ListBox();
            this.Dryness_Pnl = new System.Windows.Forms.Panel();
            this.Dryness_Lbl = new System.Windows.Forms.Label();
            this.Temp_ListBox_LBox = new System.Windows.Forms.ListBox();
            this.Temp_Sort_Pnl = new System.Windows.Forms.Panel();
            this.Temp_Sort_Lbl = new System.Windows.Forms.Label();
            this.ListBox_Btn = new System.Windows.Forms.Button();
            this.Top_Pnl = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.List_Pnl.SuspendLayout();
            this.Dryness_Pnl.SuspendLayout();
            this.Temp_Sort_Pnl.SuspendLayout();
            this.Top_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.panel1.Controls.Add(this.Help_Btn);
            this.panel1.Controls.Add(this.Indoors_Btn);
            this.panel1.Controls.Add(this.OutDorr_Btn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 877);
            this.panel1.TabIndex = 0;
            // 
            // Help_Btn
            // 
            this.Help_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Help_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Help_Btn.FlatAppearance.BorderSize = 0;
            this.Help_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Help_Btn.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Help_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Help_Btn.Image")));
            this.Help_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Help_Btn.Location = new System.Drawing.Point(0, 324);
            this.Help_Btn.Name = "Help_Btn";
            this.Help_Btn.Size = new System.Drawing.Size(200, 62);
            this.Help_Btn.TabIndex = 3;
            this.Help_Btn.Text = "Help";
            this.Help_Btn.UseVisualStyleBackColor = true;
            this.Help_Btn.Click += new System.EventHandler(this.Help_Btn_Click);
            // 
            // Indoors_Btn
            // 
            this.Indoors_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Indoors_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Indoors_Btn.FlatAppearance.BorderSize = 0;
            this.Indoors_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Indoors_Btn.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Indoors_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Indoors_Btn.Image")));
            this.Indoors_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Indoors_Btn.Location = new System.Drawing.Point(0, 262);
            this.Indoors_Btn.Name = "Indoors_Btn";
            this.Indoors_Btn.Size = new System.Drawing.Size(200, 62);
            this.Indoors_Btn.TabIndex = 2;
            this.Indoors_Btn.Text = "Indoors";
            this.Indoors_Btn.UseVisualStyleBackColor = true;
            this.Indoors_Btn.Click += new System.EventHandler(this.Indoors_Btn_Click);
            // 
            // OutDorr_Btn
            // 
            this.OutDorr_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OutDorr_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutDorr_Btn.FlatAppearance.BorderSize = 0;
            this.OutDorr_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutDorr_Btn.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.OutDorr_Btn.Image = ((System.Drawing.Image)(resources.GetObject("OutDorr_Btn.Image")));
            this.OutDorr_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutDorr_Btn.Location = new System.Drawing.Point(0, 200);
            this.OutDorr_Btn.Name = "OutDorr_Btn";
            this.OutDorr_Btn.Size = new System.Drawing.Size(200, 62);
            this.OutDorr_Btn.TabIndex = 1;
            this.OutDorr_Btn.Text = "Outdoors";
            this.OutDorr_Btn.UseVisualStyleBackColor = true;
            this.OutDorr_Btn.Click += new System.EventHandler(this.OutDorr_Btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1032, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // List_Pnl
            // 
            this.List_Pnl.Controls.Add(this.Dryness_LBox);
            this.List_Pnl.Controls.Add(this.Dryness_Pnl);
            this.List_Pnl.Controls.Add(this.Temp_ListBox_LBox);
            this.List_Pnl.Controls.Add(this.Temp_Sort_Pnl);
            this.List_Pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.List_Pnl.Location = new System.Drawing.Point(200, 0);
            this.List_Pnl.Name = "List_Pnl";
            this.List_Pnl.Size = new System.Drawing.Size(241, 877);
            this.List_Pnl.TabIndex = 2;
            // 
            // Dryness_LBox
            // 
            this.Dryness_LBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.Dryness_LBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dryness_LBox.ForeColor = System.Drawing.SystemColors.Window;
            this.Dryness_LBox.FormattingEnabled = true;
            this.Dryness_LBox.Location = new System.Drawing.Point(0, 445);
            this.Dryness_LBox.Name = "Dryness_LBox";
            this.Dryness_LBox.Size = new System.Drawing.Size(241, 432);
            this.Dryness_LBox.TabIndex = 6;
            // 
            // Dryness_Pnl
            // 
            this.Dryness_Pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.Dryness_Pnl.Controls.Add(this.Dryness_Lbl);
            this.Dryness_Pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Dryness_Pnl.Location = new System.Drawing.Point(0, 418);
            this.Dryness_Pnl.Name = "Dryness_Pnl";
            this.Dryness_Pnl.Size = new System.Drawing.Size(241, 27);
            this.Dryness_Pnl.TabIndex = 5;
            this.Dryness_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Dryness_Pnl_Paint);
            // 
            // Dryness_Lbl
            // 
            this.Dryness_Lbl.AutoSize = true;
            this.Dryness_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dryness_Lbl.Location = new System.Drawing.Point(43, 4);
            this.Dryness_Lbl.Name = "Dryness_Lbl";
            this.Dryness_Lbl.Size = new System.Drawing.Size(122, 20);
            this.Dryness_Lbl.TabIndex = 1;
            this.Dryness_Lbl.Text = "Dryness Sorting";
            // 
            // Temp_ListBox_LBox
            // 
            this.Temp_ListBox_LBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.Temp_ListBox_LBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Temp_ListBox_LBox.ForeColor = System.Drawing.SystemColors.Window;
            this.Temp_ListBox_LBox.FormattingEnabled = true;
            this.Temp_ListBox_LBox.Location = new System.Drawing.Point(0, 24);
            this.Temp_ListBox_LBox.Name = "Temp_ListBox_LBox";
            this.Temp_ListBox_LBox.Size = new System.Drawing.Size(241, 394);
            this.Temp_ListBox_LBox.TabIndex = 4;
            this.Temp_ListBox_LBox.SelectedIndexChanged += new System.EventHandler(this.Temp_ListBox_LBox_SelectedIndexChanged);
            // 
            // Temp_Sort_Pnl
            // 
            this.Temp_Sort_Pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(0)))));
            this.Temp_Sort_Pnl.Controls.Add(this.Temp_Sort_Lbl);
            this.Temp_Sort_Pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Temp_Sort_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Temp_Sort_Pnl.Name = "Temp_Sort_Pnl";
            this.Temp_Sort_Pnl.Size = new System.Drawing.Size(241, 24);
            this.Temp_Sort_Pnl.TabIndex = 3;
            // 
            // Temp_Sort_Lbl
            // 
            this.Temp_Sort_Lbl.AutoSize = true;
            this.Temp_Sort_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temp_Sort_Lbl.Location = new System.Drawing.Point(43, 3);
            this.Temp_Sort_Lbl.Name = "Temp_Sort_Lbl";
            this.Temp_Sort_Lbl.Size = new System.Drawing.Size(155, 20);
            this.Temp_Sort_Lbl.TabIndex = 0;
            this.Temp_Sort_Lbl.Text = "Temperature Sorting";
            // 
            // ListBox_Btn
            // 
            this.ListBox_Btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListBox_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ListBox_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ListBox_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ListBox_Btn.Location = new System.Drawing.Point(441, 0);
            this.ListBox_Btn.Name = "ListBox_Btn";
            this.ListBox_Btn.Size = new System.Drawing.Size(18, 877);
            this.ListBox_Btn.TabIndex = 5;
            this.ListBox_Btn.Text = ">";
            this.ListBox_Btn.UseVisualStyleBackColor = true;
            this.ListBox_Btn.Click += new System.EventHandler(this.ListBox_Btn_Click);
            // 
            // Top_Pnl
            // 
            this.Top_Pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.Top_Pnl.Controls.Add(this.pictureBox2);
            this.Top_Pnl.Controls.Add(this.dateTimePicker1);
            this.Top_Pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Pnl.Location = new System.Drawing.Point(459, 0);
            this.Top_Pnl.Name = "Top_Pnl";
            this.Top_Pnl.Size = new System.Drawing.Size(1072, 40);
            this.Top_Pnl.TabIndex = 6;
            this.Top_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Top_Pnl_MouseDown);
            this.Top_Pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Top_Pnl_MouseMove);
            this.Top_Pnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Top_Pnl_MouseUp);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(459, 40);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1072, 359);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(186)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(1531, 877);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Top_Pnl);
            this.Controls.Add(this.ListBox_Btn);
            this.Controls.Add(this.List_Pnl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.List_Pnl.ResumeLayout(false);
            this.Dryness_Pnl.ResumeLayout(false);
            this.Dryness_Pnl.PerformLayout();
            this.Temp_Sort_Pnl.ResumeLayout(false);
            this.Temp_Sort_Pnl.PerformLayout();
            this.Top_Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Indoors_Btn;
        private System.Windows.Forms.Button OutDorr_Btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Help_Btn;
        private System.Windows.Forms.Panel List_Pnl;
        private System.Windows.Forms.Panel Dryness_Pnl;
        private System.Windows.Forms.ListBox Temp_ListBox_LBox;
        private System.Windows.Forms.Panel Temp_Sort_Pnl;
        private System.Windows.Forms.Label Temp_Sort_Lbl;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox Dryness_LBox;
        private System.Windows.Forms.Label Dryness_Lbl;
        private System.Windows.Forms.Button ListBox_Btn;
        private System.Windows.Forms.Panel Top_Pnl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

