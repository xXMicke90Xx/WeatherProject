using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeatherDataLib;
using WeatherAppUI.Method_Classes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WeatherAppUI
{

    public partial class Form1 : Form
    {
        
        bool isDown = false; // Musfunktion, för att kunna dra runt rutan
        Point lastLocation; // Till för samma som ovan
        bool outSide = true;// Håller Koll på vilken knapp som är aktiv mellan inne/ute
        QueryMethods queryMethods = new QueryMethods();
        Image[] images = new Image[7];
        Calculations calculations = new Calculations();
        DateTime startDate = DateTime.Parse("2016-10-01");
        DateTime endDate = DateTime.Parse("2016-11-30");
        int timer = 0;

        public Form1()
        {
            
            InitializeComponent();
            
            DataFileRead.WriteToDatabase();
          
                
                     
           
           
            

            List_Pnl.Visible = false;
            Temp_ListBox_LBox.DataSource = queryMethods.WarmestDayToColdestAsync("Ute").Result;
            Dryness_LBox.DataSource = queryMethods.AvgHumidityOnTheWholeDataAsync("Ute").Result;
            AvgTemp_Lbl.Text += queryMethods.AvgtemperaturePerDayAsync(startDate, "Ute").Result + "°C";
            Avg_Humidity_Lbl.Text += queryMethods.AvgHumidityPerDayAsync(startDate, "Ute").Result + "%";
            Mold_Lbl.Text += queryMethods.MoldRiskAndDateResultAsync(10, 1).Result.ToString();
            //Dryness_LBox.DataSource = calulations.AvgHumidityPerDayAsync(10, 01, "Ute").Result;


            List_Pnl.Visible = false;
            OutDorr_Btn.ForeColor = Color.Blue;
            Troll_PBox.Parent = chart1;

            Troll_PBox.Dock = DockStyle.Fill;
            Troll_PBox.Visible = false;
            
            images[0] = Image.FromFile(@"Mold Pictures\\CleanRoom.jpg");
            images[1] = Image.FromFile(@"Mold Pictures\\Mold1.jpg");
            images[2] = Image.FromFile(@"Mold Pictures\\Mold2.jpg");
            images[3] = Image.FromFile(@"Mold Pictures\\Mold3.jpg");
            images[4] = Image.FromFile(@"Mold Pictures\\Mold4.jpg");
            images[5] = Image.FromFile(@"Mold Pictures\\Mold5.jpg");
            images[6] = Image.FromFile(@"Mold Pictures\\ConfusedMan.jpg");
            Mold_Lbl.Parent = Mold_PBox;
            Mold_Lbl.Dock = DockStyle.Top;

            autum_Lbl.Parent = Autum_PBox;
            autum_Lbl.Dock = DockStyle.Top;
            autum_Lbl.Text += " " + (queryMethods.MeteorologicalAutumnCalcAsync().Result.ToString() == String.Empty ? "Aldrig" : queryMethods.MeteorologicalAutumnCalcAsync().Result);

            Winter_Lbl.Dock = DockStyle.Top;
            Winter_Lbl.Parent = Winter_PBox;
            Winter_Lbl.Text += " " + (queryMethods.MeteorologicalWinterCalcAsync().Result.ToString() == String.Empty ? "Aldrig" : queryMethods.MeteorologicalWinterCalcAsync().Result);
            //ChartFunctions

            this.chart1.Titles.Add("Temperature");

            ChartFunctions.GetWeatherData(startDate, startDate.AddDays(1));
            SplineChartTemperatures(ChartFunctions.outsideData);

            //End Chart Functions
            Avg_DoorOpen_Lbl.Text = "Estimated DoorOpenTime: " + calculations.DoorOpen() + " Min";
            SetLabelValues(startDate);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            ChartFunctions.GetWeatherData(date, date.AddDays(1));
            Setchart();
            Avg_DoorOpen_Lbl.Text = "Estimated DoorOpenTime: " + calculations.DoorOpen() + " Min";
            SetLabelValues(date);
            Mold_Lbl.Text = "Riskfaktor = " + queryMethods.MoldRiskAndDateResultAsync(date.Month, date.Day).Result.ToString();
            Mold_PBox.Image = GetMoldPicture(queryMethods.MoldRiskAndDateResultAsync(date.Month, date.Day).Result);
            autum_Lbl.Text = "Metriologiska Hösten Startade"+ " " + (queryMethods.MeteorologicalAutumnCalcAsync().Result.ToString() == String.Empty ? "Aldrig" : queryMethods.MeteorologicalAutumnCalcAsync().Result);
            Winter_Lbl.Text = "Metriologiska Vintern Startade"+ " " + (queryMethods.MeteorologicalWinterCalcAsync().Result.ToString() == String.Empty ? "Aldrig" : queryMethods.MeteorologicalWinterCalcAsync().Result);
            
            if (timer > 60) //Timern är inställd på 500 millisekunder, så detta borde ske varje halv minut
            using (var c = new WeatherContext())
            {
                if (c.WeatherDatas.Where(x => x.Date == endDate).Any()) 
                    timer1.Enabled = false;
                
            }
            timer = 0;
        }


        private void Dryness_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private async Task dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Uppdaterar väder-data osv. när användaren väljer ett datum.
            DateTime date = dateTimePicker1.Value;
            ChartFunctions.GetWeatherData(date, date.AddDays(1));
            Setchart();
            Avg_DoorOpen_Lbl.Text = "Estimated DoorOpenTime: " + calculations.DoorOpen().ToString() == "0" ? "Unmeasurable" : calculations.DoorOpen().ToString() + " Min";
            SetLabelValues(date);
            Mold_Lbl.Text = "Riskfaktor = " + queryMethods.MoldRiskAndDateResultAsync(date.Month, date.Day).Result.ToString();
            Mold_PBox.Image = GetMoldPicture(queryMethods.MoldRiskAndDateResultAsync(date.Month, date.Day).Result);
        }
        

        private void OutDorr_Btn_Click(object sender, EventArgs e)
        {

            ButtonColor();
            outSide = true;
            Setchart();
            SetListBoxItems();
            SetLabelValues(dateTimePicker1.Value);
        }

        private void Indoors_Btn_Click(object sender, EventArgs e)
        {

            ButtonColor();
            outSide = false;
            Setchart();
            SetListBoxItems();
            SetLabelValues(dateTimePicker1.Value);
        }
        
        /// <summary>
        /// Sätter Listan för temperaturer, viktigt att tänka på är boolvärdet "outSide" måste vara satt innan man tillkallar denna metod!
        /// </summary>


        private void Help_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vad är det du inte fattar? Tryck OK om du e dum?");
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


        /// <summary>
        /// Skräp funktioner som råkade bli klickade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
           


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

        // Slut på skräpfunktioner




        private Image GetMoldPicture(in string newRisk)
        {
            Char.TryParse(newRisk, out char risk);
            switch (risk)
            {
                case '0':
                    return images[0];
                case '1':
                    return images[1];
                case '2':
                    return images[2];
                case '3':
                    return images[3];
                case '4':
                    return images[4];
                case '5':
                    return images[5];
                default:
                    return images[6];
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

            if (calculations.GetTempDiffPerDay(chart) > 2 && calculations.GetTempDiffPerDay(chart) < 6)
                chart1.ChartAreas[0].AxisY.Interval = 0.5f;


            foreach (var temp in chart)
            {
                if (temp != null)
                    series.Points.AddXY($"{String.Format("{0:t}", temp.Date)}", temp.Temperature);
            }
            if (chart.Count == 0)
                Troll_PBox.Visible = true;
            else
                Troll_PBox.Visible = false;
        }
        void SetLabelValues(DateTime date)
        {

            if (outSide == true)
            {
                AvgTemp_Lbl.Text = "Average Temp: " + (queryMethods.AvgtemperaturePerDayAsync(date, "Ute").Result.ToString() == "-1000" ? "Unmeasurable" : queryMethods.AvgtemperaturePerDayAsync(date, "Ute").Result.ToString() + "°C");
                Avg_Humidity_Lbl.Text = "Average Humidity: " + (queryMethods.AvgHumidityPerDayAsync(date, "Ute").Result.ToString() == "-1000" ? "Unmeasurable" : queryMethods.AvgHumidityPerDayAsync(date, "Ute").Result.ToString() + "%");               
                TempDiff_Lbl.Text = "Tempdiff: " + Math.Round(calculations.GetTempDiffPerDay(ChartFunctions.outsideData), 1) + "°C";
                TempDiff_Total_Lbl.Text = "TempdiffIn/Out: " + Math.Round(calculations.GetTempDiffPerDay(ChartFunctions.outsideData, ChartFunctions.insideData), 1) + "°C";
            }
            else
            {
                AvgTemp_Lbl.Text = "Average Temp: " + (queryMethods.AvgtemperaturePerDayAsync(date, "Inne").Result.ToString() == "-1000" ? "Unmeasurable" : queryMethods.AvgtemperaturePerDayAsync(date, "Inne").Result.ToString() + "°C");
                Avg_Humidity_Lbl.Text = "Average Humidity: " + (queryMethods.AvgHumidityPerDayAsync(date, "Inne").Result.ToString() == "-1000" ? "Unmeasurable" : queryMethods.AvgHumidityPerDayAsync(date, "Inne").Result.ToString() + "%");
                TempDiff_Lbl.Text = "Tempdiff: " + Math.Round(calculations.GetTempDiffPerDay(ChartFunctions.insideData), 1) + "°C";
                TempDiff_Total_Lbl.Text = "TempdiffIn/Out: " + Math.Round(calculations.GetTempDiffPerDay(ChartFunctions.insideData, ChartFunctions.outsideData), 1) + "°C";
            }

        }
        void SetListBoxItems() // Lägger in rätt information i ListBox beroende på om användaren valt Inside eller Outside.
        {
            if (outSide)
            {
                Temp_ListBox_LBox.DataSource = queryMethods.WarmestDayToColdestAsync("Ute").Result;
                Dryness_LBox.DataSource = queryMethods.AvgHumidityOnTheWholeDataAsync("Ute").Result;
            }
            else
            {
                Temp_ListBox_LBox.DataSource = queryMethods.WarmestDayToColdestAsync("Inne").Result;
                Dryness_LBox.DataSource = queryMethods.AvgHumidityOnTheWholeDataAsync("Inne").Result;
            }
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
        private void Setchart()
        {
            if (outSide == true)
                SplineChartTemperatures(ChartFunctions.outsideData);
            else
                SplineChartTemperatures(ChartFunctions.insideData);
        }
    }
}
