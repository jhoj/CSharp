using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Production
    {
        public int Id { get; }
        public int MachineId { get; }
        public int ProductId { get; }
        public DateTime recorded { get; }

    }
}
