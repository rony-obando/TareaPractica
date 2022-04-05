using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleAE
    {
        public int Id { get; set; }
        public int IdActivo { get; set; }
        public int IdEmpleado { get; set; }
        public long DateStart { get; set; }
    }
}
