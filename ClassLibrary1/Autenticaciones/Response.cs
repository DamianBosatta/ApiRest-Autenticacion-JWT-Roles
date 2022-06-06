using Api_Core_Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Core_Business.Autenticaciones
{
    public class Response
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }


        //public AuthenticateResponse(Usuario user, string token)
        //{
        //    Id = user.Id;
        //    FirstName = user.FirstName;
        //    LastName = user.LastName;
        //    Username = user.Username;
        //    Email = user.Email;
        //    Role = user.Role;
        //    Token = token;
        //}
    }
}
