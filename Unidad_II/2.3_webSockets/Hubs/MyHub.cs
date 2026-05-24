using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace _2._3_webSockets.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string mensaje)
        {
            await Clients.All.SendAsync("Enviar", mensaje);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("IngresoUsuario");
            await base.OnConnectedAsync();
        }

        public async Task SendGender(int valor)
        {
            await Clients.All.SendAsync("Enviar_Genero", valor);
        }


        public async Task SendUsuario(string nombre, float lat, float lon)
        {
            await Clients.All.SendAsync("Enviar_Usuario", nombre, lat, lon);
        }
    }
}