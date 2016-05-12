using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RecommendedOilConsumption
    {
        public int Id { get; }
        public string ProductMix { get; }
        public float Recommendation { get; set; }
    }
}
