using System;
using System.Collections.Generic;

namespace PruebaAdrianBack.Models;

public partial class Estudiante
{
    public int IdEstudiantes { get; set; }

    public string? NombreEstudiante { get; set; }

    public string? ApellidoEstudiante { get; set; }

    public string? CedulaEstudiante { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
