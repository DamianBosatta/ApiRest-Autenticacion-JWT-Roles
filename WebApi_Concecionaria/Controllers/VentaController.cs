using Api_Core_Business.Entidades;
using Api_Uses_Cases.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Concecionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        private readonly IUnitOfWork _context;

        public VentasController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Venta>> Get()
        {
            var entidad = _context.VentaRepo.GetAll();
            return Ok(entidad);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Venta ventas)
        {
            _context.VentaRepo.Insert(ventas);
            _context.Save();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Venta ventas, int id)
        {
            try
            {
                _context.VentaRepo.Update(ventas);
                _context.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _context.VentaRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.VentaRepo.Delete(id);
            _context.Save();

            return Ok();
        }
    }

}
