using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
    }
}
