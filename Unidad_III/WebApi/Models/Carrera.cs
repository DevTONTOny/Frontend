using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Carrera
{
    public short Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
