using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataLib;

namespace WeatherAppUI
{
    public class Calculations
    {
        public double[] AvgPerQuarter(List<WeatherData> data)
        {
            DateTime time = data[0].Date;
            double avgTemp = 0;
            int points = 0;
            int count = 0;
            double[] tempsPerQuarter = new double[144]; //96 är pga att det alltid bara finns 96 kvartar på ett dygn, kommer aldrig att ändras!

            for (int i = 0; i < data.Count; i++)
            {
                if (time.AddMinutes(10) > data[i].Date)
                {
                    avgTemp += data[i].Temperature;
                    points++;
                }
                if (time.AddMinutes(10) <= data[i].Date)
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
        public float GetTempDiffPerDay(List<WeatherData> chart)
        {
            float max = 0;
            float min = 100;
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
            return max - min;

        }
        public float GetTempDiffPerDay(List<WeatherData> chart, List<WeatherData> chart2)
        {
            float max = 0;
            float min = 100;
            foreach (var c in chart)
            {
                if (c != null)
                {
                    if (c.Temperature > max)
                    { max = c.Temperature; }

                    if (c.Temperature < min)
                        min = c.Temperature;
                }
            }
            foreach (var c in chart2)
            {
                if (c != null)
                {
                    if (c.Temperature > max)
                    { max = c.Temperature; }

                    if (c.Temperature < min)
                        min = c.Temperature;
                }
            }
            return max - min;

        }
    }
}
