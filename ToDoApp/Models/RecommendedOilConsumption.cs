using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class RecommendedOilConsumption
    {
        public int Id { get; set; }
        [Display(Name = "Product Mix")]
        public string ProductMix { get; set; }
        public float Recommendation { get; set; }
    }
}
