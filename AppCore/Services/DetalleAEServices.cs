using AppCore.IServices;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class DetalleAEServices : BaseServices<DetalleAE>, IDetalleSE
    {
        IDetalleAEModel Detalle;
        public DetalleAEServices(IDetalleAEModel model) : base(model)
        {
            Detalle = model;
        }
        public DetalleAE GetById(int id)
        {
            return Detalle.GetById(id);
        }
    }
}
