using System;
using System.Collections.Generic;

namespace PruebaAdrianBack.Models;

public partial class Curso
{
    public int IdCursos { get; set; }

    public string? NombreCursos { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
