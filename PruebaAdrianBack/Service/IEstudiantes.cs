using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Service
{
    public interface IEstudiantes
    {
        public List<EstudianteVM> ObtenerEstudiantes();
        public bool setEstudiantes(EstudianteVM estudiantes);
        public bool putEstudiantes(EstudianteVM estudiantes);
        public bool deleteEstudiantes(int idEstdudiantes);

    }
}
