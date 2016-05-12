using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RecommendedOilConsumption
    {
        public int Id { get; set; }
        public string ProductMix { get; set; }
        public float Recommendation { get; set; }
    }
}
