using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Production
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int ProductId { get; set; }
        public DateTime recorded { get; set; }

    }
}
