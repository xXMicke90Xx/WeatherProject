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
        public static void WriteToDatabase()
        {
            List<WeatherData> data = new List<WeatherData>();
            string path = @"TempFuktData.csv";
            bool title = true;
            string[] weatherFile = File.ReadAllLines(path);
            using (var c = new WeatherContext())
            {
                foreach (string line in weatherFile)
                {
                    if (title == true)
                    {
                        title = false;
                        continue;
                    }

                    string[] columns = line.Split(',');

                    var weatherData = (new WeatherData
                    {

                        Date = DateTime.Parse(columns[0].ToString()),
                        Temperature = CheckTemps(columns[2]),
                        MoistLevel = int.Parse(columns[3]),
                        Placement = columns[1]

                    });

                    data.Add(weatherData);
                }
                c.WeatherDatas.AddRange(data);
                c.SaveChanges();

            }
            float CheckTemps(string toCheck)
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
}
