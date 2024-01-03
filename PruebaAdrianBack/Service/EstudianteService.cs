using PruebaAdrianBack.Models;
using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Service
{
    public class EstudianteService:IEstudiantes
    {
        private PruebaAdrianContext _context;

        public EstudianteService(PruebaAdrianContext context)
        {
            this._context = context;
        }
        public List<EstudianteVM> ObtenerEstudiantes()
        {
            List<EstudianteVM> listaEstudiantes = new List<EstudianteVM>();
            var estudiantes = _context.Estudiantes.ToList();
            foreach (var item in estudiantes)
            {
                EstudianteVM estudiante = new EstudianteVM
                {
                    idEstudiantes = item.IdEstudiantes,
                    nombreEstudiante = item.NombreEstudiante,
                    apellidoEstudiante = item.ApellidoEstudiante,
                    cedulaEstudiante=item.CedulaEstudiante,
                    email=item.Email
                    
                };
                listaEstudiantes.Add(estudiante);
            }
            return listaEstudiantes;
        }
        public bool setEstudiantes(EstudianteVM estudiantes)
        {
            bool registrado = false;
            try
            {
                Estudiante estudianteBD = new Estudiante();
                estudianteBD.IdEstudiantes = estudiantes.idEstudiantes;
                estudianteBD.NombreEstudiante = estudiantes.nombreEstudiante;
                estudianteBD.ApellidoEstudiante = estudiantes.apellidoEstudiante;
                estudianteBD.CedulaEstudiante = estudiantes.cedulaEstudiante;
                estudianteBD.Email = estudiantes.email;
            

                _context.Estudiantes.Add(estudianteBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool putEstudiantes(EstudianteVM estudiantes)
        {
            bool registrado = false;
            try
            {
                var putEstudiantes = _context.Estudiantes.Where(x => x.IdEstudiantes == estudiantes.idEstudiantes).FirstOrDefault();
                putEstudiantes.NombreEstudiante = estudiantes.nombreEstudiante;
                putEstudiantes.ApellidoEstudiante = estudiantes.apellidoEstudiante;
                putEstudiantes.CedulaEstudiante = estudiantes.cedulaEstudiante;
                putEstudiantes.Email = estudiantes.email;
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deleteEstudiantes(int idEstudiantes)
        {
            bool registrado = false;
            var existe = _context.Registros.Where(X => X.IdPersonas == idEstudiantes).Any();
            if (!existe)
            {
                var deleteEstudiantes = _context.Estudiantes.Where(X => X.IdEstudiantes == idEstudiantes).FirstOrDefault();
                try
                {
                    _context.Estudiantes.Remove(deleteEstudiantes);
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

