namespace PruebaAdrianBack.ViewModels
{
    public class RegistroVM
    {
        public int idRegistro { get; set; }

        public int? idPersonas { get; set; }

        public int? idCursos { get; set; }

        public string? nombreEstudiante { get; set; }
        public string? apellidoEstudiante { get; set; }
        public string? nombreCurso { get; set; }


    }
    public class SetRegistroVM
    {
        public int idRegistro { get; set; }
        public int? idPersonas { get; set; }
        public int? idCursos { get; set; }
    }
}
