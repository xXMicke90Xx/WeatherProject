using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataLib
{
    public class WeatherData
    {
        
        //public int Id { get; set; }
        [Key]
        [Column(Order = 1)]
        public DateTime Date { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Placement { get; set; }
        
        public float Temperature { get; set; }
        
        public int MoistLevel { get; set; }
       




    }
}
