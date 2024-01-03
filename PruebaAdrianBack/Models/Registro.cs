using System;
using System.Collections.Generic;

namespace PruebaAdrianBack.Models;

public partial class Registro
{
    public int IdRegistro { get; set; }

    public int? IdPersonas { get; set; }

    public int? IdCursos { get; set; }

    public virtual Curso? IdCursosNavigation { get; set; }

    public virtual Estudiante? IdPersonasNavigation { get; set; }
}
