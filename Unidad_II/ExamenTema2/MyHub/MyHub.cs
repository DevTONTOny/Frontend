using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ExamenTema2.MyHub
{
    public class MyHub : Hub
    {
        public async Task SendUsuario(string nombre, float lat, float lon)
        {
            await Clients.All.SendAsync("Enviar_Usuario", nombre, lat, lon);
        }
    }
}