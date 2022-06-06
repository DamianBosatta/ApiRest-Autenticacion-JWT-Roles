

using Api_Core_Business.Entidades;
using Api_Data_Core.InterfacesRepositorios;
using Api_Generic_Core.Repositorio_Generico;
using ApiCoreBusiness;

namespace Api_Data_Core.Repositorios
{
    public class RepositoryUser : GenericRepository<Users>, IUsuarioRepositorio
    {
        public RepositoryUser(ApplicationDbContext db) : base(db)
        {
        }
     
        public bool ExisteUsuario(string email)
        {
            return _db.Usuario.Any(a => a.Email == email);
        }

        public Users GetByEmail(string email)
        {
            return _db.Usuario.FirstOrDefault(a => a.Email == email);
        }

    
    }
}

