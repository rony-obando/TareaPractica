using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryDetalleAERepository : IDetalleAEModel
    {
        private RAFContext context;
        private const int SIZE = 30;
        public BinaryDetalleAERepository()
        {
            context = new RAFContext("detalle", SIZE);
        }
        public void Add(DetalleAE t)
        {
            try
            {
                context.Create<DetalleAE>(t);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Delete(DetalleAE t)
        {
            try
            {
                context.Delete(t.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DetalleAE> Find()
        {
            throw new NotImplementedException();
        }

        public DetalleAE GetById(int id)
        {
            try
            {
                return context.Get<DetalleAE>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DetalleAE> Read()
        {
            try
            {
                return context.GetAll<DetalleAE>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(DetalleAE t)
        {
            try
            {
                return context.Update<DetalleAE>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Activo> GetActivos(int idemp)
        {
            List<Activo> activos = new List<Activo>();
            foreach (int a in context.Get<Empleado>(idemp).activos)
            {
                activos.Add(context.Get<Activo>(a));
            }
            return activos;
        }
        
    }
}
