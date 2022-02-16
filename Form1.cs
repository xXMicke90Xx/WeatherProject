using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeatherDataLib;
using WeatherAppUI.Method_Classes;
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
            Dryness_LBox.DataSource = calulations.AvgHumidityPerDayAsync(10, 01, "Ute").Result;

            List_Pnl.Visible = false;
            OutDorr_Btn.ForeColor = Color.Blue;
            //DataFileRead.WriteToDatabase();
            Mold_Lbl.Parent = Mold_PBox;
            Mold_Lbl.Dock = DockStyle.Top;

            autum_Lbl.Parent = Autum_PBox;        
            autum_Lbl.Dock = DockStyle.Top;          
            autum_Lbl.Text += " "+ calulations.MeteorologicalAutumnCalcAsync().Result;

            Winter_Lbl.Dock = DockStyle.Top;           
            Winter_Lbl.Parent = Winter_PBox;
            Winter_Lbl.Text += " " + calulations.MeteorologicalWinterCalcAsync().Result; 
            //ChartFunctions

            this.chart1.Titles.Add("Temperature");

            ChartFunctions.GetWeatherData(DateTime.Parse("2016-10-01"), DateTime.Parse("2016-10-02"));
            SplineChartTemperatures(ChartFunctions.outsideData);

            //End Chart Functions

        }
       
        void CleaningList(List<WeatherData> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i].Date == data[i + 1].Date && data[i].Temperature == data[i + 1].Temperature && data[i].Placement == data[i + 1].Placement && data[i].MoistLevel == data[i+1].MoistLevel)
                {
                    data.RemoveAt(i);
                    CleaningList(data);
                }

            }
        }
        /// <summary>
        /// Updaterar chartern med värden, baserat på en lista. listan som kommer in måste vara i rätt format dvs, innetempen eller ute tempen!
        /// </summary>
        /// <param name="chart"></param>

        private void SplineChartTemperatures(List<WeatherData> chart)
        {

            this.chart1.Series.Clear();
            Series series = chart1.Series.Add("Temperature");
            series.Color = Color.Firebrick;
            series.BorderWidth = 2;
            series.ChartType = SeriesChartType.Spline;

            chart1.ChartAreas[0].AxisX.Interval = 30;
            chart1.ChartAreas[0].AxisY.Interval = 2;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            float max = 0;
            float min = 100;
            CleaningList(chart);

            foreach (var c in chart)
            {
                if (c != null)
                {
                    if (c.Temperature > max)
                        max = c.Temperature;
                    if (c.Temperature < min)
                        min = c.Temperature;
                }
            }
            if (max < min + 3)
                chart1.ChartAreas[0].AxisY.Interval = 0.5f;


            foreach (var temp in chart)
            {
                if (temp != null)
                    series.Points.AddXY($"{String.Format("{0:t}", temp.Date)}", temp.Temperature);
                

            }
            for (int i = 0; i < chart.Count-1; i++)
            {
                if (chart[i].Date == chart[i + 1].Date && chart[i].Temperature == chart[i + 1].Temperature && chart[i].Placement == chart[i + 1].Placement && chart[i].MoistLevel == chart[i+1].MoistLevel)
                {
                    Dryness_LBox.Items.Add(chart[i].Date + " " + chart[i].Temperature);
                }
                
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
            PopulateListboxes();


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

            ButtonColor();
            outSide = true;
            Setchart();
            PopulateListboxes();



        }

        private void Indoors_Btn_Click(object sender, EventArgs e)
        {

            ButtonColor();
            outSide = false;
            Setchart();
            PopulateListboxes();


        }

        /// <summary>
        /// Sätter knappfärgen på menyvalen, tänk på att outSide bool värdet skall sättas EFTER att denna är tillkallad, dvs, trycks indoors knappen, tillkalla denna och SEDAN ändra värdet, bakvänt men spelar ingen roll i denna situation.
        /// </summary>
        void ButtonColor()
        {
            if (outSide == true)
            {
                Indoors_Btn.ForeColor = Color.Blue;
                OutDorr_Btn.ForeColor = Color.Black;
            }
            else
            {
                OutDorr_Btn.ForeColor = Color.Blue;
                Indoors_Btn.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Sätter Listan för temperaturer, viktigt att tänka på är boolvärdet "outSide" måste vara satt innan man tillkallar denna metod!
        /// </summary>
        void PopulateListboxes()
        {
            if (outSide == true)
            {
                Temp_ListBox_LBox.DataSource = calulations.WarmestDayToColdestAsync("Ute").Result;
                Dryness_LBox.DataSource = calulations.AvgHumidityPerDayAsync(dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, "Ute").Result;
            }
            else
            {
                Temp_ListBox_LBox.DataSource = calulations.WarmestDayToColdestAsync("Inne").Result;
                Dryness_LBox.DataSource = calulations.AvgHumidityPerDayAsync(dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, "Inne").Result;
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
