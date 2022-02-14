using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataLib;
using WeatherAppUI;

namespace WeatherAppUI.Method_Classes
{
    public class Calulations
    {
        public async Task<List<string>> WarmestDayToColdest(string input)
        {
            using (var context = new WeatherContext())
            {
                var averageTempQ = context.WeatherDatas.Where(x => x.Placement.Contains(input))
                     .GroupBy(x => new { x.Date.Month, x.Date.Day })
                     .Select(x => new { Date = x.Key, Temperature = x.Average(y => y.Temperature) })
                     .OrderByDescending(x => x.Temperature)
                     .ToList();
                List<string> result = averageTempQ.Select(x => x.ToString()).ToList();
                return await Task.FromResult(result);
            }
            
        }
    }
}
