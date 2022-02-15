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
using WeatherAppUI.Method_Classes;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            Temp_ListBox_LBox.DataSource = calulations.WarmestDayToColdestAsync("Ute").Result;


            List_Pnl.Visible = false;
            OutDorr_Btn.ForeColor = Color.Blue;
            //DataFileRead.WriteToDatabase();

            autum_Lbl.Parent = Autum_PBox;
            Winter_Lbl.Parent = Winter_PBox;
            autum_Lbl.Dock = DockStyle.Top;
            Winter_Lbl.Dock = DockStyle.Top;


            //ChartFunctions

            this.chart1.Titles.Add("Temperature");
            
            ChartFunctions.GetWeatherData(DateTime.Parse("2016-10-01"), DateTime.Parse("2016-10-02"));
            SplineChartTemperatures(ChartFunctions.outsideData);

            //End Chart Functions

        }

        

        private void SplineChartTemperatures(List<WeatherData> chart)
        {
            this.chart1.Series.Clear();
            Series series = chart1.Series.Add("Temperature");
            series.Color = Color.Firebrick;
            series.BorderWidth = 2;
            series.ChartType = SeriesChartType.Spline;
            
            chart1.ChartAreas[0].AxisX.Interval = 31;
            chart1.ChartAreas[0].AxisY.Interval = 2;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            float max = 0;
            float min = 100;
            foreach(var c in chart)
            {
                if (c.Temperature > max)
                    max = c.Temperature;
                if(c.Temperature < min)
                    min = c.Temperature;
            }
            if (max < min+3)
                chart1.ChartAreas[0].AxisY.Interval = 0.5f;


            string hours = ChartFunctions.outsideData[0].Date.Hour.ToString();
            string minutes = ChartFunctions.outsideData[0].Date.Minute.ToString();

            series.Points.AddXY(chart[0].Date.Hour.ToString(), chart[0].Temperature);
            foreach (var temp in chart)
            {
                hours = temp.Date.Hour.ToString();
                minutes = temp.Date.Minute.ToString();

                series.Points.AddXY($"{hours}:{minutes}", temp.Temperature);            
            }          
        }

        private void Dryness_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime date = dateTimePicker1.Value;
            ChartFunctions.GetWeatherData(date, date.AddDays(1));
            Setchart();


        }
        private void Setchart()
        {
            if (outSide == true)
                SplineChartTemperatures(ChartFunctions.outsideData);
            else
                SplineChartTemperatures(ChartFunctions.insideData);
        }

        private void OutDorr_Btn_Click(object sender, EventArgs e)
        {
            if (outSide == false)
            {
                OutDorr_Btn.ForeColor = Color.Blue;
                Indoors_Btn.ForeColor = Color.Black;
                outSide = true;
                Setchart(); 
               
            }
        }

        private void Indoors_Btn_Click(object sender, EventArgs e)
        {
            if (outSide == true)
            {
                Indoors_Btn.ForeColor = Color.Blue;
                OutDorr_Btn.ForeColor = Color.Black;
                outSide = false;
                Setchart();      
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
            // TODO: This line of code loads data into the 'weatherDBDataSet.WeatherDatas' table. You can move, or remove it, as needed.
            this.weatherDatasTableAdapter.Fill(this.weatherDBDataSet.WeatherDatas);


        }



        private void Temp_ListBox_LBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void autum_Lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
