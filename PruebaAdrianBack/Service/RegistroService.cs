using PruebaAdrianBack.Models;
using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Service
{
    public class RegistroService:IRegistro
    {
        private PruebaAdrianContext _context;

        public RegistroService(PruebaAdrianContext context)
        {
            this._context = context;
        }
        public List<RegistroVM> ObtenerRegistro()
        {
            List<RegistroVM> lista = new List<RegistroVM>();
            var relacion = (from registro in _context.Registros
                            join estudiantes in _context.Estudiantes
                            on registro.IdPersonas equals estudiantes.IdEstudiantes
                            join cursos in _context.Cursos
                            on registro.IdCursos equals cursos.IdCursos
                            where registro.IdRegistro != 0
                            select new
                            {
                                registro.IdRegistro,
                                registro.IdCursos,
                                registro.IdPersonas,
                                estudiantes.NombreEstudiante,
                                estudiantes.ApellidoEstudiante,
                                cursos.NombreCursos
                              
                            }
                            ).ToList();
            foreach (var item in relacion)
            {
                RegistroVM registro = new RegistroVM
                {
                    idRegistro = item.IdRegistro,
                    idCursos = item.IdCursos,
                    idPersonas = item.IdPersonas,
                    nombreEstudiante= item.NombreEstudiante,
                    apellidoEstudiante= item.ApellidoEstudiante,
                    nombreCurso=item.NombreCursos
                };
                lista.Add(registro);
            }
            return lista;

        }

        public bool SetRegistro(SetRegistroVM setRegistro)
        {
            bool registrado = false;

            var existe = _context.Registros.Where(x => x.IdPersonas == setRegistro.idPersonas).Any();
            if (!existe)
            {
                try
                {
                    Registro registroBD = new Registro();
                    registroBD.IdPersonas = setRegistro.idPersonas;
                    registroBD.IdCursos = setRegistro.idCursos;
                    _context.Registros.Add(registroBD);
                    _context.SaveChanges();
                    registrado = true;
                }
                catch (Exception)
                {
                    registrado = false;
                }
            }
            else
            {
                Console.WriteLine("La persona ya tiene un curso");
                registrado = false;
            }
            return registrado;
        }

        public List<RegistroVM> ObtenerRegistroById(int id)
        {
            List<RegistroVM> lista = new List<RegistroVM>();
            var relacion = (from registro in _context.Registros
                            join estudiantes in _context.Estudiantes
                            on registro.IdPersonas equals estudiantes.IdEstudiantes
                            join cursos in _context.Cursos
                            on registro.IdCursos equals cursos.IdCursos
                            where registro.IdRegistro == id
                            select new
                            {
                                registro.IdRegistro,
                                registro.IdCursos,
                                registro.IdPersonas,
                                estudiantes.NombreEstudiante,
                                estudiantes.ApellidoEstudiante,
                                cursos.NombreCursos

                            }
                            ).ToList();
            foreach (var item in relacion)
            {
                RegistroVM registro = new RegistroVM
                {
                    idRegistro = item.IdRegistro,
                    idCursos = item.IdCursos,
                    idPersonas = item.IdPersonas,
                    nombreEstudiante = item.NombreEstudiante,
                    apellidoEstudiante = item.ApellidoEstudiante,
                    nombreCurso = item.NombreCursos
                };
                lista.Add(registro);
            }
            return lista;

        }
    }
}
