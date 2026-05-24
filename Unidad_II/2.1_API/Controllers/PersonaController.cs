using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._1_API.models;
using Microsoft.AspNetCore.Mvc;

namespace _2._1_API.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Persona>> getPersona()
        {
            return new List<Persona>
            {
                new Persona {Nombre = "Yahir", edad = 23, Genero = "Masculino"},
                new Persona {Nombre = "Diego", edad = 30, Genero = "Masculino"},
                new Persona {Nombre = "Miguel de jesus", edad = 25, Genero = "Masculino"},
                new Persona {Nombre = "Ana", edad = 28, Genero = "Femenino"},
                new Persona {Nombre = "Maria", edad = 22, Genero = "Femenino"},
                new Persona {Nombre = "Diana", edad = 22, Genero = "Femenino"},
                new Persona {Nombre = "Jose de jesus", edad = 25, Genero = "Masculino"},


            };
        }
    }
}