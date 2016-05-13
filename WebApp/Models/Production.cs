using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Production
    {
        public int Id { get; set; }
        [Display(Name = "Machine ID")]
        public int MachineId { get; set; }
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [DataType(DataType.Date)]
        public DateTime recorded { get; set; }

    }
}
