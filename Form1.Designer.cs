namespace WeatherAppUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Syncfusion.Windows.Forms.Chart.ChartSeries chartSeries1 = new Syncfusion.Windows.Forms.Chart.ChartSeries();
            Syncfusion.Windows.Forms.Chart.ChartDataBindModel chartDataBindModel1 = new Syncfusion.Windows.Forms.Chart.ChartDataBindModel();
            Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo chartCustomShapeInfo1 = new Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo();
            Syncfusion.Windows.Forms.Chart.ChartLineInfo chartLineInfo1 = new Syncfusion.Windows.Forms.Chart.ChartLineInfo();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.weatherDBDataSet1 = new WeatherAppUI.WeatherDBDataSet1();
            this.weatherDBDataSet = new WeatherAppUI.WeatherDBDataSet();
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
            this.Minutes_Hour_Btn = new System.Windows.Forms.Button();
            this.weatherDatasTableAdapter = new WeatherAppUI.WeatherDBDataSetTableAdapters.WeatherDatasTableAdapter();
            this.weatherDatasTableAdapter1 = new WeatherAppUI.WeatherDBDataSet1TableAdapters.WeatherDatasTableAdapter();
            this.Temperature_Chart = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.weatherDBDataSet2 = new WeatherAppUI.WeatherDBDataSet2();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.weatherDatasTableAdapter2 = new WeatherAppUI.WeatherDBDataSet2TableAdapters.WeatherDatasTableAdapter();
            this.weatherDBDataSet3 = new WeatherAppUI.WeatherDBDataSet3();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.weatherDatasTableAdapter3 = new WeatherAppUI.WeatherDBDataSet3TableAdapters.WeatherDatasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.List_Pnl.SuspendLayout();
            this.Dryness_Pnl.SuspendLayout();
            this.Temp_Sort_Pnl.SuspendLayout();
            this.Top_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "WeatherDatas";
            this.bindingSource2.DataSource = this.weatherDBDataSet1;
            // 
            // weatherDBDataSet1
            // 
            this.weatherDBDataSet1.DataSetName = "WeatherDBDataSet1";
            this.weatherDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // weatherDBDataSet
            // 
            this.weatherDBDataSet.DataSetName = "WeatherDBDataSet";
            this.weatherDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.Top_Pnl.Controls.Add(this.Minutes_Hour_Btn);
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
            // Minutes_Hour_Btn
            // 
            this.Minutes_Hour_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minutes_Hour_Btn.Location = new System.Drawing.Point(934, 9);
            this.Minutes_Hour_Btn.Name = "Minutes_Hour_Btn";
            this.Minutes_Hour_Btn.Size = new System.Drawing.Size(75, 23);
            this.Minutes_Hour_Btn.TabIndex = 8;
            this.Minutes_Hour_Btn.Text = "Hours";
            this.Minutes_Hour_Btn.UseVisualStyleBackColor = true;
            this.Minutes_Hour_Btn.Click += new System.EventHandler(this.Minutes_Hour_Btn_Click);
            // 
            // weatherDatasTableAdapter
            // 
            this.weatherDatasTableAdapter.ClearBeforeFill = true;
            // 
            // weatherDatasTableAdapter1
            // 
            this.weatherDatasTableAdapter1.ClearBeforeFill = true;
            // 
            // Temperature_Chart
            // 
            this.Temperature_Chart.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(219))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(8)))), ((int)(((byte)(56))))));
            this.Temperature_Chart.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent);
            this.Temperature_Chart.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.Temperature_Chart.ChartArea.CursorReDraw = false;
            this.Temperature_Chart.ChartInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent);
            this.Temperature_Chart.CustomPalette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(144)))), ((int)(((byte)(34))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(190)))), ((int)(((byte)(82))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(222)))), ((int)(((byte)(37))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(66)))), ((int)(((byte)(153))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(90)))), ((int)(((byte)(36))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(38)))))};
            this.Temperature_Chart.DataSourceName = "bindingSource2";
            this.Temperature_Chart.Dock = System.Windows.Forms.DockStyle.Top;
            this.Temperature_Chart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.IsWindowLess = false;
            // 
            // 
            // 
            this.Temperature_Chart.Legend.Location = new System.Drawing.Point(58, 75);
            this.Temperature_Chart.Legend.Orientation = Syncfusion.Windows.Forms.Chart.ChartOrientation.Horizontal;
            this.Temperature_Chart.Legend.Position = Syncfusion.Windows.Forms.Chart.ChartDock.Top;
            this.Temperature_Chart.Localize = null;
            this.Temperature_Chart.Location = new System.Drawing.Point(459, 40);
            this.Temperature_Chart.Name = "Temperature_Chart";
            this.Temperature_Chart.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Custom;
            this.Temperature_Chart.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.Temperature_Chart.PrimaryXAxis.Margin = true;
            this.Temperature_Chart.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText;
            this.Temperature_Chart.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.Temperature_Chart.PrimaryYAxis.Margin = true;
            this.Temperature_Chart.PrimaryYAxis.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Temperature_Chart.PrimaryYAxis.TitleColor = System.Drawing.SystemColors.ControlText;
            chartSeries1.FancyToolTip.ResizeInsideSymbol = true;
            chartSeries1.Name = "Temps";
            chartSeries1.Resolution = 0D;
            chartDataBindModel1.DataSource = this.bindingSource2;
            chartDataBindModel1.XName = "Date";
            chartDataBindModel1.YNames = new string[] {
        "Temperature"};
            chartSeries1.SeriesModel = chartDataBindModel1;
            chartSeries1.StackingGroup = "Default Group";
            chartSeries1.Style.AltTagFormat = "";
            chartSeries1.Style.Border.Width = 2F;
            chartSeries1.Style.DisplayShadow = true;
            chartSeries1.Style.DrawTextShape = false;
            chartLineInfo1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            chartLineInfo1.Color = System.Drawing.SystemColors.ControlText;
            chartLineInfo1.DashPattern = null;
            chartLineInfo1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartLineInfo1.Width = 1F;
            chartCustomShapeInfo1.Border = chartLineInfo1;
            chartCustomShapeInfo1.Color = System.Drawing.SystemColors.HighlightText;
            chartCustomShapeInfo1.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square;
            chartSeries1.Style.TextShape = chartCustomShapeInfo1;
            chartSeries1.Text = "Temps";
            chartSeries1.Type = Syncfusion.Windows.Forms.Chart.ChartSeriesType.Spline;
            this.Temperature_Chart.Series.Add(chartSeries1);
            this.Temperature_Chart.Size = new System.Drawing.Size(1072, 402);
            this.Temperature_Chart.TabIndex = 7;
            this.Temperature_Chart.Text = "Temperature Chart";
            // 
            // 
            // 
            this.Temperature_Chart.Title.Name = "Default";
            this.Temperature_Chart.Titles.Add(this.Temperature_Chart.Title);
            this.Temperature_Chart.VisualTheme = "";
            // 
            // weatherDBDataSet2
            // 
            this.weatherDBDataSet2.DataSetName = "WeatherDBDataSet2";
            this.weatherDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "WeatherDatas";
            this.bindingSource1.DataSource = this.weatherDBDataSet2;
            // 
            // weatherDatasTableAdapter2
            // 
            this.weatherDatasTableAdapter2.ClearBeforeFill = true;
            // 
            // weatherDBDataSet3
            // 
            this.weatherDBDataSet3.DataSetName = "WeatherDBDataSet3";
            this.weatherDBDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource3
            // 
            this.bindingSource3.DataMember = "WeatherDatas";
            this.bindingSource3.DataSource = this.weatherDBDataSet3;
            // 
            // weatherDatasTableAdapter3
            // 
            this.weatherDatasTableAdapter3.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(186)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(1531, 877);
            this.Controls.Add(this.Temperature_Chart);
            this.Controls.Add(this.Top_Pnl);
            this.Controls.Add(this.ListBox_Btn);
            this.Controls.Add(this.List_Pnl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.List_Pnl.ResumeLayout(false);
            this.Dryness_Pnl.ResumeLayout(false);
            this.Dryness_Pnl.PerformLayout();
            this.Temp_Sort_Pnl.ResumeLayout(false);
            this.Temp_Sort_Pnl.PerformLayout();
            this.Top_Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDBDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
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
        private WeatherDBDataSet weatherDBDataSet;
        private WeatherDBDataSetTableAdapters.WeatherDatasTableAdapter weatherDatasTableAdapter;
        private WeatherDBDataSet1 weatherDBDataSet1;
        private WeatherDBDataSet1TableAdapters.WeatherDatasTableAdapter weatherDatasTableAdapter1;
        private Syncfusion.Windows.Forms.Chart.ChartControl Temperature_Chart;
        private System.Windows.Forms.Button Minutes_Hour_Btn;
        public System.Windows.Forms.BindingSource bindingSource2;
        private WeatherDBDataSet2 weatherDBDataSet2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private WeatherDBDataSet2TableAdapters.WeatherDatasTableAdapter weatherDatasTableAdapter2;
        private WeatherDBDataSet3 weatherDBDataSet3;
        private System.Windows.Forms.BindingSource bindingSource3;
        private WeatherDBDataSet3TableAdapters.WeatherDatasTableAdapter weatherDatasTableAdapter3;
    }
}

