using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeatherDataLib;
using WeatherAppUI.Method_Classes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;

namespace WeatherAppUI
{

    public partial class Form1 : Form
    {

        bool isDown = false; // Musfunktion, för att kunna dra runt rutan
        Point lastLocation; // Till för samma som ovan
        bool outSide = true;// Håller Koll på vilken knapp som är aktiv mellan inne/ute
        QueryMethods queryMethods = new QueryMethods();
        Image[] images = new Image[5];

        public Form1()
        {
            InitializeComponent();

            List_Pnl.Visible = false;
            Temp_ListBox_LBox.DataSource = queryMethods.WarmestDayToColdestAsync("Ute").Result;
            Dryness_LBox.DataSource = queryMethods.AvgHumidityOnTheWholeDataAsync("Ute").Result;
            AvgTemp_Lbl.Text += queryMethods.AvgtemperaturePerDayAsync(DateTime.Parse("2016-10-01"), "Ute").Result + "°C";
            Avg_Humidity_Lbl.Text += queryMethods.AvgHumidityPerDayAsync(DateTime.Parse("2016-10-01"), "Ute").Result + "%";
            Mold_Lbl.Text += queryMethods.MoldRiskAndDateResultAsync(10, 1).Result.ToString();
            //Dryness_LBox.DataSource = calulations.AvgHumidityPerDayAsync(10, 01, "Ute").Result;


            List_Pnl.Visible = false;
            OutDorr_Btn.ForeColor = Color.Blue;
            //DataFileRead.WriteToDatabase(); // Ta bort kommentar före metod-anropet för att skapa databas från .csv-fil vid körtid.
            images[0] = Image.FromFile(@"mögelbilder\\mögel7.jpg");
            images[1] = Image.FromFile(@"mögelbilder\\mögel1.jpg");
            images[2] = Image.FromFile(@"mögelbilder\\mögel6.jpg");
            images[3] = Image.FromFile(@"mögelbilder\\mögel2.jpg");
            images[4] = Image.FromFile(@"mögelbilder\\mögel3.jpg");
            Mold_Lbl.Parent = Mold_PBox;
            Mold_Lbl.Dock = DockStyle.Top;

            autum_Lbl.Parent = Autum_PBox;
            autum_Lbl.Dock = DockStyle.Top;
            autum_Lbl.Text += " " + queryMethods.MeteorologicalAutumnCalcAsync().Result;

            Winter_Lbl.Dock = DockStyle.Top;
            Winter_Lbl.Parent = Winter_PBox;
            Winter_Lbl.Text += " " + queryMethods.MeteorologicalWinterCalcAsync().Result;
            //ChartFunctions

            this.chart1.Titles.Add("Temperature");

            ChartFunctions.GetWeatherData(DateTime.Parse("2016-10-01"), DateTime.Parse("2016-10-02"));
            SplineChartTemperatures(ChartFunctions.outsideData);

            //End Chart Functions
            DoorOpen();
        }
        double[] AvgPerQuarter(List<WeatherData> data)
        {
            DateTime time = data[0].Date;
            double avgTemp = 0;
            int points = 0;
            int count = 0;
            double[] tempsPerQuarter = new double[96]; //96 är pga att det alltid bara finns 96 kvartar på ett dygn, kommer aldrig att ändras!

            for (int i = 0; i < data.Count; i++)
            {
                if (time.AddMinutes(15) > data[i].Date)
                {
                    avgTemp += data[i].Temperature;
                    points++;
                }
                if (time.AddMinutes(15) <= data[i].Date)
                {
                    tempsPerQuarter[count] = Math.Round(avgTemp / points, 1); // Lägger in medeltemperatur i listan.
                    count++;
                    points = 0; // Nollställer dessa inför nästa varv i loopen.
                    avgTemp = 0;
                    time = data[i].Date;
                }
            }

            return tempsPerQuarter;
        }

        void DoorOpen()
        {
            //Dryness_LBox.Items.Clear();
            if (ChartFunctions.outsideData.Count == 0 || ChartFunctions.insideData.Count == 0) return;

            double[] outsideTemps = AvgPerQuarter(ChartFunctions.outsideData); // Lägger in genomsnittlig temperatur per kvart ute
            double[] insideTemps = AvgPerQuarter(ChartFunctions.insideData); // Lägger in genomsnittlig temperatur per kvart inne

            for (int i = 0; i < insideTemps.Length - 1; i++)
            {

                if (outsideTemps[i] < outsideTemps[i + 1] && insideTemps[i] > insideTemps[i + 1]) //TODO: Fixa bättre kalkyl!
                {
                    //Dryness_LBox.Items.Add($"{outsideTemps[i]}/{outsideTemps[i + 1]}  {String.Format("{0:t}", ChartFunctions.insideData[0].Date.AddMinutes(i * 15))}=>{String.Format("{0:t}", ChartFunctions.insideData[0].Date.AddMinutes(i * 15 + 30))}   {insideTemps[i]}/{insideTemps[i + 1]}");
                }

            }
        }

        List<WeatherData> CleaningList(List<WeatherData> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i].Date == data[i + 1].Date && data[i].Temperature == data[i + 1].Temperature && data[i].Placement == data[i + 1].Placement && data[i].MoistLevel == data[i + 1].MoistLevel)
                {
                    data.RemoveAt(i);
                    CleaningList(data); // Kör om metoden tills inte längre kommer in i if-satsen. Då bör allt vara rensat.
                }

            }
            return data;
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
            if (max < min + 5)
                chart1.ChartAreas[0].AxisY.Interval = 0.5f;


            foreach (var temp in chart)
            {
                if (temp != null)
                    series.Points.AddXY($"{String.Format("{0:t}", temp.Date)}", temp.Temperature);
            }

        }

        private void Dryness_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Uppdaterar väder-data osv. när användaren väljer ett datum.
            DateTime date = dateTimePicker1.Value;
            ChartFunctions.GetWeatherData(date, date.AddDays(1));
            Setchart();
            DoorOpen();
            TempAndHumidityLabels(date);
            Mold_Lbl.Text = "MögelRisken = " + queryMethods.MoldRiskAndDateResultAsync(date.Month, date.Day).Result;
            Mold_PBox.Image = GetMoldPicture(queryMethods.MoldRiskAndDateResultAsync(date.Month, date.Day).Result);
        }
        void TempAndHumidityLabels(DateTime date)
        {

            if (outSide == true)
            {

                AvgTemp_Lbl.Text = "Average Temp: " + queryMethods.AvgtemperaturePerDayAsync(date, "Ute").Result + "°C";
                Avg_Humidity_Lbl.Text = "Average Humidity: " + queryMethods.AvgHumidityPerDayAsync(date, "Ute").Result + "%";
            }
            else
            {
                AvgTemp_Lbl.Text = "Average Temp: " + queryMethods.AvgtemperaturePerDayAsync(date, "Inne").Result + "°C";
                Avg_Humidity_Lbl.Text = "Average Humidity: " + queryMethods.AvgHumidityPerDayAsync(date, "Inne").Result + "%";
            }

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
            SetListBoxItems();
            TempAndHumidityLabels(dateTimePicker1.Value);
        }

        private void Indoors_Btn_Click(object sender, EventArgs e)
        {

            ButtonColor();
            outSide = false;
            Setchart();
            SetListBoxItems();
            TempAndHumidityLabels(dateTimePicker1.Value);
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
                default:
                    return null;
            }
        }
    }
}
