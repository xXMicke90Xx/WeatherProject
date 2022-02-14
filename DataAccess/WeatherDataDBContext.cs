using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace WeatherDataLib
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherDB")
        {

        }
        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
