using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryActivoRepository : IActivoModel
    {
        private RAFContext context;
        private const int SIZE = 981;
        public BinaryActivoRepository()
        {
            context = new RAFContext("activo", SIZE);
            
        }
        public void Add(Activo t)
        {
            try
            {
                context.Create<Activo>(t);
            }
            catch (IOException)
            {
                throw;
            }
        }

        public void Delete(Activo t)
        {
            try
            {
                context.Delete(t.Id);
            }
            catch (IOException)
            {
                throw;
            }

        }

        public Activo GetById(int id)
        {
            try
            {
                return context.Get<Activo>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Activo> Read()
        {
            try
            {
                return context.GetAll<Activo>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Activo t)
        {
            return context.Update<Activo>(t);
        }

        public List<Activo> Find()
        {
            throw new NotImplementedException();
        }
    }
}
