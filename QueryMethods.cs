using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataLib;
using WeatherAppUI;
using System.Collections;

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
        public async Task<float> AvgHumidityPerDayAsync(DateTime date, string placement)
        {
            using (var context = new WeatherContext())
            {
                float result = -1000;
                try
                {
                    result = (float)Math.Round(context.WeatherDatas.Where(y => y.Date.Month == date.Month && y.Date.Day == date.Day && y.Placement.ToLower() == placement.ToLower()).Average(x => x.MoistLevel), 1);
                }
                catch (Exception)
                {

                }

                return await Task.FromResult((float)result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="placement"></param>
        /// <returns></returns>
        public Task<float> AvgtemperaturePerDayAsync(DateTime date, string placement)
        {
            using (var context = new WeatherContext())
            {

                float result = -1000;
                try
                {
                    result = (float)Math.Round(context.WeatherDatas.Where(y => y.Date.Month == date.Month && y.Date.Day == date.Day && y.Placement.ToLower() == placement.ToLower()).Average(x => x.Temperature), 1);
                }
                catch (Exception)
                {
                    
                }
                
                return Task.FromResult((float)result);
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
                   .Select(c => new { Date = c.Key, AverageTemp = c.Average(y => y.Temperature) })
                   .OrderBy(c => c.Date.Month)
                   .ThenBy(c => c.Date.Day)
                   .Where(c => c.AverageTemp > 0 && c.AverageTemp < 10)
                   .Take(5)
                   .ToList();

                List<string> output = averageTempQuery.Select(x => String.Format("{1}/{0}", x.Date.Month, x.Date.Day)).ToList();
                
                if (output.Count >= 5)
                    return await Task.FromResult(output.Last().ToString());
                else
                    return await Task.FromResult(string.Empty);
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
                if (result.Count >= 5)
                return await Task.FromResult(result.Last().ToString()); 
                else
                return await Task.FromResult(string.Empty);
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
        /// <summary>
        /// Kör en query för att filtrera utedata på luftfuktighet temp,datum
        /// Hänger ihop med RunMoldCalcAndFilterAsync
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<List<dynamic>> MoldIndexQueryAsync(int month, int day)
        {
            using (var context = new WeatherContext())
            {
                var mold = context.WeatherDatas.Where(c => c.MoistLevel > 0 && c.Placement.Contains("Ute") && c.Temperature >= 0 && c.Date.Month == month && c.Date.Day == day)
                    .GroupBy(c => new { c.Date.Month, c.MoistLevel })
                    .Select(c => new { Moist = c.Key, AverageTemp = c.Average(y => y.Temperature), }).OrderByDescending(c => c.AverageTemp)
                    .Take(1)
                    .ToList();
                List<dynamic> result = mold.ToList<dynamic>();
                return await Task.FromResult(result);
            }
        }
        /// <summary>
        /// Här körs resultatet ifrån MoldIndexQueryAsync
        /// och kollar av risken 
        /// Den i sin tur retunerar ett hashtable 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<Hashtable> RunMoldCalcAndFilterAsync(int month, int day)
        {
            Hashtable riskAssesement = new Hashtable();
            var run = MoldIndexQueryAsync(month, day);
            var result = run.Result;
            foreach (var item in result)
            {
                if (item.Moist.MoistLevel > 0 && item.Moist.MoistLevel < 75 && item.AverageTemp <= 18)
                {
                    int risk0 = 0;
                    riskAssesement.Add(item, risk0);

                }
                else if (item.Moist.MoistLevel > 75 && item.Moist.MoistLevel < 80 && item.AverageTemp <= 30)
                {
                    int risk1 = 1;
                    riskAssesement.Add(item, risk1);
                }
                else if (item.Moist.MoistLevel > 80 && item.Moist.MoistLevel < 85 && item.AverageTemp <= 30)
                {
                    int risk2 = 2;
                    riskAssesement.Add(item, risk2);
                }
                else if (item.Moist.MoistLevel > 85 && item.Moist.MoistLevel < 90 && item.AverageTemp <= 30)
                {
                    int risk3 = 3;
                    riskAssesement.Add(item, risk3);
                }
                else if (item.Moist.MoistLevel > 90 && item.Moist.MoistLevel < 95 && item.AverageTemp <= 30)
                {
                    int risk4 = 4;
                    riskAssesement.Add(item, risk4);
                }
                else if (item.Moist.MoistLevel > 95 && item.Moist.MoistLevel <= 100 && item.AverageTemp <= 30)
                {
                    int risk5 = 5;
                    riskAssesement.Add(item, risk5);

                }
            }
            return await Task.FromResult(riskAssesement);
        }
        /// <summary>
        /// Här får vi in ett hashtable, Går igenom den och binder riskvärdet till
        /// en sträng. Redo att presenteras för användaren på valt datum
        /// Denna metoden kopplas till vad änvändaren gör för val på
        /// månad och dag.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<string> MoldRiskAndDateResultAsync(int month, int day)
        {
            var run = RunMoldCalcAndFilterAsync(month, day);
            var result = run.Result;
            string riskValue = "";
            foreach (DictionaryEntry entry in result)
            {
                riskValue += entry.Value;
            }
            if (riskValue == "")
            {
                riskValue = "Gick ej att beräkna";
            }
            return await Task.FromResult(riskValue);
        }
    }
}
