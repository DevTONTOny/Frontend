using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _2._1_API.Controllers
{
    [ApiController]
    [Route("api/Estadisticas")]
    public class EstadisticasController: ControllerBase
    {
        [HttpGet]
        public List<Estadistica> getEstadisticas()
        {
            List<Estadistica> estadisticas = new List<Estadistica>();
            int anio = 2018;
            for (int i = 0; i <= 5; i++)
            {
                estadisticas.Add(new Estadistica
                {
                    Anio = anio,
                    Total = new Random().Next(1, 100)
                });
                anio++;
            }
            return estadisticas;
        }

    }
}