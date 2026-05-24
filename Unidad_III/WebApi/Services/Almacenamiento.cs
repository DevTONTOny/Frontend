using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class Almacenamiento : IAlmacenamiento
    {

        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Almacenamiento(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AlmacenarImagen(string contenedor, IFormFile archivo)
        {
            var extension = Path.GetExtension(archivo.FileName);
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            var carpeta = Path.Combine(env.WebRootPath, contenedor);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            string ruta = Path.Combine(carpeta, nombreArchivo);
            using(var es = new MemoryStream())
            {
                await archivo.CopyToAsync(es);
                var contenido = es.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);
            }
            var request = httpContextAccessor.HttpContext!.Request;
            var url = $"{request.Scheme}://{request.Host}";
            var archivoUrl = Path.Combine(url, contenedor, nombreArchivo)
                                        .Replace("\\","/");
            return archivoUrl;
        }

        public Task Eliminar(string? ruta, string carpeta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return Task.CompletedTask;
            }
            var nombreArchivo = Path.GetFileName(ruta);
            var directorio = Path.Combine(env.WebRootPath, carpeta, nombreArchivo);
            if (File.Exists(directorio))
            {
                File.Delete(directorio);
            }
            return Task.CompletedTask;
        }
    }
}