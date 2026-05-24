using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Fotografia
    {
        public string Nombre {get; set;} = null;
        public IFormFile? Foto { get; set; }
        
    }
}