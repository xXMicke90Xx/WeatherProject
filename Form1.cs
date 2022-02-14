using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WeatherDataLib;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Syncfusion.Windows.Forms.Chart;
using WeatherAppUI.Method_Classes;


namespace WeatherAppUI
{

    public partial class Form1 : Form
    {

        bool isDown = false; // Musfunktion, för att kunna dra runt rutan
        Point lastLocation; // Till för samma som ovan
        bool outSide = true;// Håller Koll på vilken knapp som är aktiv mellan inne/ute
        Calulations calulations = new Calulations();
        
        public Form1()
        {
            InitializeComponent();

            List_Pnl.Visible = false;
            Temp_ListBox_LBox.DataSource = calulations.WarmestDayToColdest("Ute").Result;
            

            List_Pnl.Visible = false;
            OutDorr_Btn.ForeColor = Color.Blue;
            //DataFileRead.WriteToDatabase();


            //ChartFunctions
            bindingSource2.DataSource = ChartFunctions.outsideData;
            ChartFunctions.GetWeatherData(DateTime.Parse("2016-10-01"), DateTime.Parse("2016-10-02"));
            SetChartDetails();
            SetChartToHours(DateTime.Parse("2016-10-01"));
            UpdateDataBindingForChart();
            //End Chart Functions

        }
        
        private void Dryness_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            DateTime date = dateTimePicker1.Value;
            ChartFunctions.GetWeatherData(date, date.AddDays(1));
            UpdateDataBindingForChart();
            SetChartDetails();
            Temperature_Chart.Update();

        }

        private void OutDorr_Btn_Click(object sender, EventArgs e)
        {
            if (outSide == false)
            {
                OutDorr_Btn.ForeColor = Color.Blue;
                Indoors_Btn.ForeColor = Color.Black;
                outSide = true;
                Temp_ListBox_LBox.DataSource = calulations.WarmestDayToColdest("Ute").Result; // ~150ms
                UpdateDataBindingForChart(); // ~250ms
            }
        }

        private void Indoors_Btn_Click(object sender, EventArgs e)
        {
            if (outSide == true)
            {
                Indoors_Btn.ForeColor = Color.Blue;
                OutDorr_Btn.ForeColor = Color.Black;
                outSide = false;
                Temp_ListBox_LBox.DataSource = calulations.WarmestDayToColdest("Inne").Result; // ~150ms
                UpdateDataBindingForChart(); // ~250ms
            }
        }

        private void Help_Btn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Top_Pnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Location.Y);

                this.Update();
            }
        }

        private void Top_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            lastLocation = e.Location;
        }

        private void Top_Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void ListBox_Btn_Click(object sender, EventArgs e)
        {
            if (List_Pnl.Visible == true) // If panel is visable when click, change stuff
            {
                List_Pnl.Visible = false;
                ListBox_Btn.Text = ">";


            }
            else // Open the panel, set the pictureboxlocation
            {
                List_Pnl.Visible = true;
                ListBox_Btn.Text = "<";

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'weatherDBDataSet3.WeatherDatas' table. You can move, or remove it, as needed.
            this.weatherDatasTableAdapter3.Fill(this.weatherDBDataSet3.WeatherDatas);
            // TODO: This line of code loads data into the 'weatherDBDataSet2.WeatherDatas' table. You can move, or remove it, as needed.
            this.weatherDatasTableAdapter2.Fill(this.weatherDBDataSet2.WeatherDatas);
            // TODO: This line of code loads data into the 'weatherDBDataSet1.WeatherDatas' table. You can move, or remove it, as needed.
            this.weatherDatasTableAdapter1.Fill(this.weatherDBDataSet1.WeatherDatas);
            // TODO: This line of code loads data into the 'weatherDBDataSet.WeatherDatas' table. You can move, or remove it, as needed.


        }



        private void Temp_ListBox_LBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void SetChartDetails() // Skulle vela bryta ut dessa funktioner, men det fungerar inte som det ska då! 
        {
            this.Temperature_Chart.PrimaryXAxis.IntervalType = ChartDateTimeIntervalType.Days;
            this.Temperature_Chart.PrimaryXAxis.LabelIntersectAction = ChartLabelIntersectAction.Rotate;

            this.Temperature_Chart.PrimaryXAxis.ValueType = ChartValueType.DateTime;
            this.Temperature_Chart.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;

            this.Temperature_Chart.PrimaryXAxis.DateTimeFormat = "HH:mm";

            if (Minutes_Hour_Btn.Text == "Minutes") SetChartToHours(dateTimePicker1.Value); else SetChartToMinutes(dateTimePicker1.Value);
        }
        void SetChartToMinutes(DateTime start)
        {
            this.Temperature_Chart.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(start, start.AddMinutes(1440), 60, ChartDateTimeIntervalType.Minutes);

            this.Temperature_Chart.PrimaryXAxis.DateTimeInterval.Type = ChartDateTimeIntervalType.Minutes;


        }
        void SetChartToHours(DateTime start)
        {
            this.Temperature_Chart.PrimaryXAxis.DateTimeRange = new ChartDateTimeRange(start, start.AddHours(24), 1, ChartDateTimeIntervalType.Hours);

            this.Temperature_Chart.PrimaryXAxis.DateTimeInterval.Type = ChartDateTimeIntervalType.Hours;


        }

        private void Minutes_Hour_Btn_Click(object sender, EventArgs e)
        {
            if (Minutes_Hour_Btn.Text == "Hours")
            {
                Minutes_Hour_Btn.Text = "Minutes";
                SetChartDetails();
                UpdateDataBindingForChart();
                Temperature_Chart.Update();
            }
            else if (Minutes_Hour_Btn.Text == "Minutes")
            {
                Minutes_Hour_Btn.Text = "Hours";
                SetChartDetails();
                UpdateDataBindingForChart();
                Temperature_Chart.Update();
            }
        }
        public void UpdateDataBindingForChart()
        {
            
            if (outSide == true)
            {

                bindingSource2.DataSource = ChartFunctions.outsideData;

            }
            else
            {
                bindingSource2.DataSource = ChartFunctions.insideData;

            }
        }
    }
}
