using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.dto
{
    public class AlumnosDTO
    {
    public string NumeroControl { get; set; } = null!;

    public string? Nombre { get; set; }

    public short? Semestre { get; set; }

    public short? IdCarrera { get; set; }

   public string? Imagen { get; set; } 

    }
}