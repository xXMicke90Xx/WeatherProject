using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

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
