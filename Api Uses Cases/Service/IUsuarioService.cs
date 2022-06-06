using Api_Core_Business.Autenticaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Uses_Cases.Service
{
    public interface IUsuarioService
    {
        Response Registrar(Request usuario, string password);
        Response Login(string email, string password);
        string GetToken(Response usuario);
    }
}
