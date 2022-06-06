using Api_Core_Business.Autenticaciones;
using Api_Data_Core.Repositorios;
using Api_Uses_Cases.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api_Core_Business.Entidades;

namespace Api_Uses_Cases.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uOW;
        private readonly IConfiguration _configuration;
    public UsuarioService(IUnitOfWork uow, IConfiguration configuration)
    {
        _uOW = uow;
        _configuration = configuration;
    }
    public string GetToken(Response usuario)
    {
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Expires = DateTime.UtcNow.AddMinutes(120),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = credentials

        };
        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public Response Login(string email, string password)
    {                                                                                                                                                                                                           
        if (_uOW.UserRepo.ExisteUsuario(email))
        {
           Response response = new Response();
                //traigo el usuario, por el email
                Users user = _uOW.UserRepo.GetByEmail(email);
            //verifico si el password ingresado es el mismo del usuario en la DB
            if (!VerificarPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            //aca deberia mappear a un UserResponse
            response.Email = email;
                response.Nombre = user.Nombre;
            response.Id = user.Id;
            response.Role = user.Role;
            //Devuelvo la respuesta si esta todo bien
            return response;
        }
        return null;
    }

    private bool VerificarPassword(string pass, byte[] pHash, byte[] pSalt)
    {
        //hago una encriptacion con la key (psalt)
        var hMac = new HMACSHA512(pSalt);
        var hash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
        //comparo el pass de la DB con el que acabo de encriptar
        for (var i = 0; i < hash.Length; i++)
        {
            if (hash[i] != pHash[i]) return false;
        }

        return true;
    }

    private void CrearPassHash(string pass, out byte[] passwordHash, out byte[] passwordSalt)
    {
        //creo una encriptacion
        var hMac = new HMACSHA512();
        //le asigno la llave de la encriptacion al passwordSalt
        passwordSalt = hMac.Key;
        //Encripto el pass y lo guardo en passwordHash
        passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));


    }

    public Response Registrar(Request user, string password)
    {
        byte[] passwordHash;
        byte[] passwordSalt;
        CrearPassHash(password, out passwordHash, out passwordSalt);
        Users usuario = new Users();
        usuario.Nombre = user.Username;
        usuario.Email = user.Email;
        usuario.PasswordHash = passwordHash;
        usuario.PasswordSalt = passwordSalt;
        usuario.Role = Role.Admin;
        _uOW.UserRepo.Insert(usuario);
        _uOW.Save();
        Response response = new Response();
        response.Email = usuario.Email;
        response.Nombre = usuario.Nombre;
        response.Id = usuario.Id;
        response.Role = usuario.Role;
        return response;
    }
}
}
