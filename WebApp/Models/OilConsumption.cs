using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OilConsumption
    {
        public int Id { get; }
        public float Liters { get; }
        public DateTime recorded { get; }
    }
}
