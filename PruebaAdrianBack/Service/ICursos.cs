using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Service
{
    public interface ICursos
    {
        public List<CursoVM> ObtenerCursos();

        public bool setCursos(CursoVM cursos);
        public bool putCursos(CursoVM cursos);
        public bool deleteCursos(int idCursos);
    }
}
