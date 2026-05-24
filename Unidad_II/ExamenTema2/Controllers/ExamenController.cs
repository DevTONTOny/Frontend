using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ExamenTema2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTema2.Controllers
{
    [ApiController]
    [Route("api/Examen")]
    public class ExamenController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult GetPacientes(int id)
        {
            List<User> users = new List<User>
            {
                new User{ latitude=22.141637891066658, longitude= -100.96725444678991, name="Ezequiel", photo="https://randomuser.me/api/portraits/men/0.jpg"},
                new User{ latitude=19.440712871373186, longitude= -102.06588713842402, name="Luis", photo="https://randomuser.me/api/portraits/men/1.jpg"},
                new User{ latitude=21.161379433540052, longitude= -86.86081068620823, name="Juan Carlos", photo="https://randomuser.me/api/portraits/men/2.jpg"},
                new User{ latitude=17.082182935404067, longitude= -96.7316136466776, name="Isaac", photo="https://randomuser.me/api/portraits/men/3.jpg"},
                new User{ latitude=19.180393205750022, longitude= -96.13062281239132, name="Yahir", photo="https://randomuser.me/api/portraits/men/4.jpg"},
                new User{ latitude=20.691037290395933, longitude= -103.32944830373056, name="Gabriel", photo="https://randomuser.me/api/portraits/men/5.jpg"},
                new User{ latitude=22.774557325002196, longitude= -102.58049692170154, name="Gilberto", photo="https://randomuser.me/api/portraits/men/6.jpg"},
                new User{ latitude=23.23751155798351,  longitude= -106.42484104069487, name="Juan Manuel", photo="https://randomuser.me/api/portraits/men/7.jpg"},
                new User{ latitude=28.64048391017918,   longitude= -106.06995013171866, name="Antuan", photo="https://randomuser.me/api/portraits/men/8.jpg"},
                new User{ latitude=22.909463847756662,    longitude= -109.91183437720592, name="Diego", photo="https://randomuser.me/api/portraits/men/9.jpg"},
            };
            
            if (id < 0 || id > 9 )
            {
                return NotFound();
            }
            return Ok(users[id]);
        }
    }
}