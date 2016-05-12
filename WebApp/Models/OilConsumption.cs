using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OilConsumption
    {
        public int Id { get; set; }
        public float Liters { get; set; }
        public DateTime recorded { get; set; }
    }
}
