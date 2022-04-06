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
        public Activo IdActivo { get; set; }
        public Empleado IdEmpleado { get; set; }
        public long DateStart { get; set; }
    }
}
