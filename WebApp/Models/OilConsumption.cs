using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OilConsumption
    {
        public int Id { get; set; }
        public float Liters { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Recorded")]
        public DateTime recorded { get; set; }
    }
}
