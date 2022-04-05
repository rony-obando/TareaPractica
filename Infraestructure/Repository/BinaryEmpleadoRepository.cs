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
    public class BinaryEmpleadoRepository : IEmpleadoModel
    {
        private RAFContext<Empleado> context;
        private const int SIZE = 576;
        public BinaryEmpleadoRepository()
        {
            context = new RAFContext<Empleado>("empleado", SIZE);
        }
        public void Add(Empleado t)
        {
            try
            {
                context.Create<Empleado>(t);
            }
            catch (IOException)
            {
                throw;
            }
        }

        public void Delete(Empleado t)
        {
            try
            {
                context.Delete<Empleado>(t);
            }
            catch (IOException)
            {
                throw;
            }
        }

        public List<Empleado> Find()
        {
            throw new NotImplementedException();
        }

        public Empleado GetById(int id)
        {
            try
            {
                return context.Get<Empleado>(id);
            }
            catch (IOException)
            {
                throw;
            }
        }

        public List<Empleado> Read()
        {
            try
            {
                return context.GetAll<Empleado>();
            }
            catch (IOException)
            {
                throw;
            }
        }

        public int Update(Empleado t)
        {
            try
            {
                return context.Update<Empleado>(t);
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
