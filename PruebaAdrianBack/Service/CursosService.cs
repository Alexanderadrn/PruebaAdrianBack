using PruebaAdrianBack.Models;
using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Service
{
    public class CursosService:ICursos
    {
        private PruebaAdrianContext _context;

        public CursosService(PruebaAdrianContext context)
        {
            this._context = context;
        }
        public List<CursoVM> ObtenerCursos()
        {
            List<CursoVM> listaCursos = new List<CursoVM>();
            var cursos = _context.Cursos.ToList();
            foreach (var item in cursos)
            {
                CursoVM curso = new CursoVM
                {
                    idCursos = item.IdCursos,
                    nombreCursos = item.NombreCursos,

                };
                listaCursos.Add(curso);
            }
            return listaCursos;
        }
        public bool setCursos(CursoVM cursos)
        {
            bool registrado = false;
            try
            {
                Curso cursoBD = new Curso();
                cursoBD.IdCursos = cursos.idCursos;
                cursoBD.NombreCursos = cursos.nombreCursos;
                


                _context.Cursos.Add(cursoBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool putCursos(CursoVM cursos)
        {
            bool registrado = false;
            try
            {
                var putCursos = _context.Cursos.Where(x => x.IdCursos == cursos.idCursos).FirstOrDefault();
                putCursos.NombreCursos = cursos.nombreCursos;
                
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deleteCursos(int idCursos)
        {
            bool registrado = false;
            var existe = _context.Registros.Where(x => x.IdCursos == idCursos).Any();
            if (!existe)
            {
                var deleteCursos = _context.Cursos.Where(X => X.IdCursos == idCursos).FirstOrDefault();
                try
                {
                    _context.Cursos.Remove(deleteCursos);
                    _context.SaveChanges();
                    registrado = true;
                }
                catch
                {
                    registrado = false;
                }
                return registrado;
            }
            else
            {
                return false;
            }
            
        }
    }
}
