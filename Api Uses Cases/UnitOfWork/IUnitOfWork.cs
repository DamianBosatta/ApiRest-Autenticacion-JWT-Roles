using Api_Data_Core.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Uses_Cases.UnitOfWork
{
    public interface IUnitOfWork : IDisposable

    {



        IRepositoryCliente ClienteRepo { get; }
        IRepositoryVenta VentaRepo { get; }
        IRepositoryVehiculo VehiculoRepo { get; }
        IUsuarioRepositorio UserRepo { get; }
        void Save();


    }
}
