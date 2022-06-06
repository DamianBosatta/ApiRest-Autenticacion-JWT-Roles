using Api_Core_Business.Autenticaciones;
using Api_Uses_Cases.Service;
using Api_Uses_Cases.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Concecionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    { 
        private readonly IUsuarioService _usuarioService;
    private readonly IUnitOfWork _uow;

    public LoginController(IUsuarioService usuarioService, IUnitOfWork uow)
    {
        _usuarioService = usuarioService;
        _uow = uow;
    }
    [HttpPost]
    public ActionResult Login([FromBody] Request req)
    {
        var response = _usuarioService.Login(req.Email, req.Password);
        if (response == null)
        {
            return Unauthorized();
        }
        var token = _usuarioService.GetToken(response);
        return Ok(new
        {
            token = token,
            usuario = response
        });
    }
    [HttpPost("Registro")]
    public ActionResult RegistrarUsuario([FromBody] Request user)
    {
        if (_uow.UserRepo.ExisteUsuario(user.Email.ToLower()))
        {
            return BadRequest("Ya existe un cuenta asociada a ese Email");
        }
        Response res = _usuarioService.Registrar(user, user.Password);
        return Ok(res);
    }
}
}
