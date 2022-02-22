using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppUI;

namespace WeatherDataLib
{
    public static class DataFileRead
    {
        static StreamWriter sw = new StreamWriter("fel.txt");


        public static void WriteToDatabase()
        {
            
            var listToRead = new List<WeatherData>();
            string path = @"TempFuktData.csv";
            bool title = true;
            string[] weatherFile = File.ReadAllLines(path);
            var weatherData = new WeatherData();
            var data = new Dictionary<Tuple<DateTime, string>, WeatherData>();
            foreach (string line in weatherFile)
            {
                string[] columns = line.Split(',');
                if (title == true)
                {
                    title = false;
                    continue;
                }

                weatherData = (new WeatherData
                {

                    Date = DateTime.Parse(columns[0].ToString()),
                    Temperature = CheckTemps(columns[2]),
                    MoistLevel = int.Parse(columns[3]),
                    Placement = columns[1]

                });

                listToRead.Add(weatherData);
                
                

            }


            RemoveDups(listToRead, data);
           
            using (var c = new WeatherContext())
            {
                c.WeatherDatas.AddRange(data.Values);
                c.SaveChanges();
            }

        }

        public static void RemoveDups(List<WeatherData> listToRead, Dictionary<Tuple<DateTime, string>, WeatherData> data)
        {
            foreach(var item in listToRead)
            {
                try
                {
                    data.Add(Tuple.Create(item.Date, item.Placement), item);
                }
                catch { }
            }

        }

        static float CheckTemps(string toCheck)
        {
            if (float.TryParse(toCheck, NumberStyles.Float, CultureInfo.InvariantCulture, out float output))
                return output;
            else
                        if (float.TryParse(toCheck.Substring(1), NumberStyles.Float, CultureInfo.InvariantCulture, out float output2))
                return output2 * -1;
            return -1000;
        }

    }
}

