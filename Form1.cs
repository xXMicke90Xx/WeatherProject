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
           
            ChartFunctions.GetWeatherData(DateTime.Parse("2016-10-01"), DateTime.Parse("2016-10-02"));
            
            chart1.AlignDataPointsByAxisLabel();
            weatherDatasBindingSource.DataSource = ChartFunctions.outsideData;
            //End Chart Functions

        }
        
        private void Dryness_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            DateTime date = dateTimePicker1.Value;
            ChartFunctions.GetWeatherData(date, date.AddDays(1));
            if (outSide == true)
            {
                weatherDatasBindingSource.DataSource = ChartFunctions.outsideData;
                chart1.DataBind();
                
            }
            else
            {
                weatherDatasBindingSource.DataSource = ChartFunctions.insideData;
                chart1.DataBind();
                
            }

        }

        private void OutDorr_Btn_Click(object sender, EventArgs e)
        {
            if (outSide == false)
            {
                OutDorr_Btn.ForeColor = Color.Blue;
                Indoors_Btn.ForeColor = Color.Black;
                outSide = true;
                weatherDatasBindingSource.DataSource = ChartFunctions.outsideData;
                chart1.DataBind();
            }
        }

        private void Indoors_Btn_Click(object sender, EventArgs e)
        {
            if (outSide == true)
            {
                Indoors_Btn.ForeColor = Color.Blue;
                OutDorr_Btn.ForeColor = Color.Black;
                outSide = false;
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = ChartFunctions.insideData.Count + 500;
                
                weatherDatasBindingSource.DataSource = ChartFunctions.insideData;
                chart1.DataBind();

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
    }
}
