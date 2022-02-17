using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataLib;
using WeatherAppUI;

namespace WeatherAppUI.Method_Classes
{
    public class QueryMethods
    {
        /// <summary>
        /// In parametrar är månad,dag samt plats inne || ute.
        /// Ut kommer genomsnittstempen på det datum och plats man 
        /// har valt.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="placement"></param>
        /// <returns></returns>
        public async Task<List<string>> AvgTempGroupByDateAsync(int month, int day, string placement)
        {
            using (var context = new WeatherContext())
            {
                var averageTemp = context.WeatherDatas.Where(c => c.Placement.Contains(placement) && c.Date.Month == month && c.Date.Day == day)//FÖR VALT DATUM!!!!! inte plats
                .GroupBy(c => new { c.Date.Month, c.Date.Day })
                .Select(c => new { Day = c.Key, AverageTemp = c.Average(y => y.Temperature) })
                .ToList();
                List<string> result = averageTemp.Select(x => String.Format("Månad:{0}:Dag{1} | Genomsnittlig Temperatur {2}", x.Day.Month, x.Day.Day, x.AverageTemp)).ToList();
                return await Task.FromResult(result);
            }
        }
        /// <summary>
        /// Input ska då vara från vilken plats man vill få ut datan på
        /// Sedan kommer det en lista som är sorterad med Varmaste till kallaste tempen 
        /// Baserat på den plats användaren väljer, inne || ute
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<List<string>> WarmestDayToColdestAsync(string input)
        {
            using (var context = new WeatherContext())
            {
                var warmToCold = context.WeatherDatas.Where(x => x.Placement.Contains(input))
                     .GroupBy(x => new { x.Date.Month, x.Date.Day })
                     .Select(x => new { Date = x.Key, Temperature = x.Average(y => y.Temperature) })
                     .OrderByDescending(x => x.Temperature)
                     .ToList();
                List<string> result = warmToCold.Select(x => String.Format("Månad:{0}:Dag{1} | Temperatur {2}", x.Date.Month, x.Date.Day, Math.Round(x.Temperature))).ToList();
                return await Task.FromResult(result);
            }

        }
        /// <summary>
        /// Genomsnittlig luftfuktighet beräknat på datum samt plats
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="placement"></param>
        /// <returns></returns>
        public async Task<List<string>> AvgHumidityPerDayAsync(int month, int day, string placement)
        {
            using (var context = new WeatherContext())
            {
                var averageHumidityQuery = context.WeatherDatas.Where(c => c.Placement.Contains(placement) && c.Date.Month == month && c.Date.Day == day)
                .GroupBy(c => new { c.Date.Month, c.Date.Day })
                .Select(c => new { Date = c.Key, AverageMoist = c.Average(y => y.MoistLevel) }).OrderByDescending(c => c.AverageMoist)
                .ToList();
                List<string> result = averageHumidityQuery.Select(x => String.Format("Månad:{0},Dag{1} | Luftfuktighet {2} %", x.Date.Month, x.Date.Day, Math.Round(x.AverageMoist, 2))).ToList();
                return await Task.FromResult(result);
            }
        }
        /// <summary>
        /// Metod för att beräkna när hösten inföll på testdatan
        /// </summary>
        /// <returns></returns>
        public async Task<string> MeteorologicalAutumnCalcAsync()
        {
            //Den meteorologiska definitionen av höst är att dygnsmedeltemperaturen ska vara
            //sjunkande och lägre än 10,0 plusgrader men högre än 0,0°, på mindre data räcker det med lägre än 10 i fem dygn
            using (var context = new WeatherContext())
            {
                var averageTempQuery = context.WeatherDatas.Where(c => c.Placement.Contains("Ute"))
                   .GroupBy(c => new { c.Date.Month, c.Date.Day })
                   .Select(c => new { Date = c.Key, AverageTemp = c.Average(y => y.Temperature) }).OrderByDescending(c => c.Date.Month)
                   .Where(c => c.AverageTemp > 0 && c.AverageTemp < 10)
                   .ToList();
                var result = averageTempQuery.OrderByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).ThenBy(x => x.AverageTemp).ToList();
                var result2 = result.Skip(Math.Max(0, result.Count - 5));

                List<string> output = result2.Select(x => String.Format("{1}/{0}", x.Date.Month, x.Date.Day)).ToList();
                output.Reverse();
                return await Task.FromResult(output[0]);
            }
        }
        /// <summary>
        /// Query som kollar om det blev någon vinter på den datan som finns
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> MeteorologicalWinterCalcAsync()
        {
            using (var context = new WeatherContext())
            {
                var averageTempQuery = context.WeatherDatas.Where(c => c.Placement.Contains("Ute"))
                   .GroupBy(c => new { c.Date.Month, c.Date.Day })
                   .Select(c => new { Date = c.Key, AverageTemp = c.Average(y => y.Temperature) }).OrderBy(c => c.AverageTemp)
                   .Where(c => c.AverageTemp <= 0)
                   .ToList();
                List<string> result = averageTempQuery.Select(x => String.Format("{1}/{0}", x.Date.Month, x.Date.Day)).ToList();
                string message = "Det saknas ett dygn för att meteorologisk vinter skall kunna uppstå";
                result.Add(message);
                return await Task.FromResult(result[0]);
            }
        }
        /// <summary>
        /// Metod för att hämta in hela datamängden och beräkna 
        /// luftfuktighten per dag,baserat på plats.
        /// placement kan då vara "Ute" | "Inne"
        /// </summary>
        /// <param name="placement"></param>
        /// <returns></returns>
        public async Task<List<string>> AvgHumidityOnTheWholeDataAsync(string placement)
        {
            using (var context = new WeatherContext())
            {
                var averageHumidityQuery = context.WeatherDatas.Where(c => c.Placement.Contains(placement))
                .GroupBy(c => new { c.Date.Month, c.Date.Day })
                .Select(c => new { Date = c.Key, AverageMoist = c.Average(y => y.MoistLevel) }).OrderByDescending(c => c.AverageMoist)
                .ToList();
                List<string> result = averageHumidityQuery.Select(x => String.Format("Månad:{0}:Dag{1} | Luftfuktighet {2} %", x.Date.Month, x.Date.Day, Math.Round(x.AverageMoist, 2))).ToList();
                return await Task.FromResult(result);
            }

        }
    }
}
