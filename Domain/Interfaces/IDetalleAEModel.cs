using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDetalleAEModel:IModel<DetalleAE>
    {
        DetalleAE GetById(int id);
        List<Activo> GetActivos(int idemp);
    }
}
