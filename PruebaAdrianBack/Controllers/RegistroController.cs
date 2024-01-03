using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAdrianBack.Service;
using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        public IRegistro registro;
        public RegistroController(IRegistro _registro)
        {
            this.registro = _registro;
        }
        [HttpGet("ObtenerRegistro")]
        public ActionResult ObtenerRegistro()
        {
            return new JsonResult(registro.ObtenerRegistro());
        }
        [HttpPost("setRegistro")]
        public bool setEmpleado(SetRegistroVM registros)
        {
            return registro.SetRegistro(registros);
        }
        [HttpGet("ObtenerRegistroId")]
        public ActionResult ObtenerRegistroById(int id)
        {
            return new JsonResult(registro.ObtenerRegistroById(id));
        }
    }
}
