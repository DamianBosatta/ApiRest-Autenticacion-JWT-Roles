using Api_Core_Business.Entidades;
using Api_Data_Core.InterfacesRepositorios;
using Api_Generic_Core.Repositorio_Generico;
using ApiCoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Data_Core.Repositorios
{
    public class RepositoryVehiculo : GenericRepository<Vehiculo>, IRepositoryVehiculo
    {
        public RepositoryVehiculo(ApplicationDbContext db) : base(db)
        {
        }
    }
}
