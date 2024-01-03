using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAdrianBack.Service;
using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        public ICursos curso;
        public CursosController(ICursos _curso)
        {
            this.curso = _curso;
        }
        [HttpGet("ObtenerCursos")]
        public ActionResult ObtenerEstudiantes()
        {
            return new JsonResult(curso.ObtenerCursos());
        }
        [HttpPost("setCursos")]
        public bool setCursos(CursoVM cursos)
        {
            return curso.setCursos(cursos);
        }
        [HttpPost("putCursos")]
        public bool putEstudiantes(CursoVM cursos)
        {
            return curso.putCursos(cursos);
        }
        [HttpPost("deleteCurso")]
        public bool deleteEstudiante(int id)
        {
            return curso.deleteCursos(id);
        }
    }
}
