using Api_Data_Core.InterfacesRepositorios;
using Api_Data_Core.Repositorios;
using ApiCoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Uses_Cases.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {


        private readonly ApplicationDbContext _context;

        public IRepositoryCliente ClienteRepo { get; private set; }

        public IRepositoryVenta VentaRepo { get; private set; }

        public IRepositoryVehiculo VehiculoRepo { get; private set; }

        public IUsuarioRepositorio UserRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ClienteRepo = new RepositoryCliente(context);
            VentaRepo = new RepositoryVenta(context);
            VehiculoRepo = new RepositoryVehiculo(context);
            UserRepo = new RepositoryUser(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
