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
            List<int> Ids = new List<int>();
            BinaryActivoRepository binaryActivo = new BinaryActivoRepository();
            BinaryEmpleadoRepository binaryEmpleado = new BinaryEmpleadoRepository();
            for (int i=0;i<Read().Count;i++)
            {
                if (Read()[i].IdEmpleado.Id==idemp)
                {
                    if (Ids.Count >= 1)
                    {
                        for(int j = 0; j < Ids.Count; j++) { 
                        if (Ids[j]!=Read()[j].IdActivo.Id)
                        {
                                activos.Add(binaryActivo.GetById(Read()[i].IdActivo.Id));
                        }
                        }
                    }
                    else
                    {
                        activos.Add(binaryActivo.GetById(Read()[i].IdActivo.Id));
                        Ids.Add(Read()[i].IdActivo.Id);
                    }
                }
            }
            return activos;
        }
        
    }
}
