using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using WeatherDataLib;


namespace WeatherAppUI.Method_Classes
{
    public static class ChartFunctions
    {
        
        public static List<WeatherData> outsideData = new List<WeatherData>();
        
        public static List<WeatherData> insideData = new List<WeatherData>();
        
        public static DateTime start = DateTime.Parse("2016-10-01");
        public static List<WeatherData> GetWeatherData(DateTime startDate, DateTime endDate)
        {
            List<WeatherData> data = new List<WeatherData>();
            using (var c = new WeatherContext())
            {
                
                outsideData = c.WeatherDatas.Where(x => x.Date > startDate && x.Date < endDate && x.Placement.ToLower() == "ute").Distinct().ToList();

                insideData = c.WeatherDatas.Where(x => x.Date > startDate && x.Date < endDate && x.Placement.ToLower() == "inne").Distinct().ToList();
            }

            return data;
        }








    }
}
