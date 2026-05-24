using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.dto
{
    public class AlumnosDTOCrear
    {
    public string NumeroControl { get; set; } = null!;

    public string? Nombre { get; set; }

    public short? Semestre { get; set; }

    public short? IdCarrera { get; set; }
    public IFormFile? Imagen { get; set; }

    }
}