using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _2._3_webSockets.Controllers
{

    public class SocketsController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult EnviarPersona()
        {
            return View();
        }

        public IActionResult Graficas()
        {
            return View();
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public IActionResult Mapa()
        {
            return View();
        }
        
    }
}