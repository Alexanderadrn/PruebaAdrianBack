using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAdrianBack.Service;
using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        public IEstudiantes estudiante;
        public EstudiantesController(IEstudiantes _estudiante)
        {
            this.estudiante = _estudiante;
        }
        [HttpGet("ObtenerEstudiantes")]
        public ActionResult ObtenerEstudiantes()
        {
            return new JsonResult(estudiante.ObtenerEstudiantes());
        }
        [HttpPost("setEstudiantes")]
        public bool setEmpleado(EstudianteVM estudiantes)
        {
            return estudiante.setEstudiantes(estudiantes);
        }
        [HttpPost("putEstudiantes")]
        public bool putEstudiantes(EstudianteVM estudiantes)
        {
            return estudiante.putEstudiantes(estudiantes);
        }
        [HttpPost("deleteEstudiante")]
        public bool deleteEstudiante(int id)
        {
            return estudiante.deleteEstudiantes(id);
        }
    }
}

