using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataLib
{
    public static class DataFileRead
    {
        static StreamWriter sw = new StreamWriter("fel.txt");


        public static void WriteToDatabase()
        {
            var listToRead = new Dictionary<Tuple<DateTime, string>, WeatherData>();
            string path = @"TempFuktData.csv";
            bool title = true;
            string[] weatherFile = File.ReadAllLines(path);
            var weatherData = new WeatherData();
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
                try
                {
                    listToRead.Add(Tuple.Create(weatherData.Date, weatherData.Placement), weatherData);
                }
                catch
                {

                }



            }
            using (var C = new WeatherContext())
            {
                C.WeatherDatas.AddRange((IEnumerable<WeatherData>)listToRead);
                C.SaveChanges();
            }


            void Test(string line)
            {
                

                
                
                






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

