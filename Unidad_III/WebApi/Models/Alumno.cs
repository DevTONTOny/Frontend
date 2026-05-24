using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Alumno
{
    public string NumeroControl { get; set; } = null!;

    public string? Nombre { get; set; }

    public short? Semestre { get; set; }

    public short? IdCarrera { get; set; }

    public string? Imagen { get; set; }

    public virtual Carrera? IdCarreraNavigation { get; set; }
}
