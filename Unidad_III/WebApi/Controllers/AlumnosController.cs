using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.dto;
using WebApi.Models;
using WebApi.Services;

namespace WebAPIAngular.Controllers
{
    [ApiController]
    [Route("api/Alumnos")]
    public class AlumnosController : ControllerBase
    {
        private readonly DbEscuelaContext db;
        private readonly IMapper mapper;
        private readonly IAlmacenamiento almacenador;

        public AlumnosController(DbEscuelaContext db, IMapper mapper, IAlmacenamiento a)
        {
            this.db = db;
            this.mapper = mapper;
            this.almacenador = a;
        }

        [HttpGet]
        public async Task<List<AlumnosDTO>> Get()
        {
            var alumnos = await db.Alumnos.OrderBy(x => x.NumeroControl).ToListAsync();
            return mapper.Map<List<AlumnosDTO>>(alumnos);
        }

        [HttpGet("MostrarTodos")]
        public async Task<IActionResult>MostrarTodos()
        {
            return Ok(await db.Alumnos.Include(x => x.IdCarreraNavigation)
            .Select(
                x => new
                {
                    noControl = x.NumeroControl,
                    nombre = x.Nombre,
                    semestre = x.Semestre,
                    carrera = x.IdCarreraNavigation!.Nombre,
                    imagen = x.Imagen
                }
            ).ToListAsync());
        }

        [HttpGet("Buscar/{nc}")]
        public async Task<IActionResult> GetAlumno(string nc)
        {
            var alumnos = await db.Alumnos.FirstOrDefaultAsync(x => x.NumeroControl == nc);
            if (alumnos == null)
                return NotFound();
            return Ok(mapper.Map<AlumnosDTO>(alumnos));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AlumnosDTOCrear alumnosDTO)
        {
            var alumno = mapper.Map<Alumno>(alumnosDTO);

            string urlFoto = "";
                if(alumnosDTO.Imagen is not null)
                {
                    urlFoto = await almacenador.AlmacenarImagen("Alumnos", alumnosDTO.Imagen);
                    alumno.Imagen = urlFoto;
                }
            await db.Alumnos.AddAsync(alumno);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromForm] AlumnosDTOCrear alumnosDTO)
        {
            var alumnoCreado = mapper.Map<Alumno>(alumnosDTO);
             string urlFoto = alumnoCreado.Imagen ?? "";
                if(alumnosDTO.Imagen is not null)
                {
                    urlFoto = await almacenador.AlmacenarImagen("Alumnos", alumnosDTO.Imagen);
                    alumnoCreado.Imagen = urlFoto;
                }
            var existe = await db.Alumnos.AnyAsync(x => x.NumeroControl == id);
            if (!existe)
                return NotFound();
            var alumno = mapper.Map<Alumno>(alumnoCreado);
            alumno.NumeroControl = id;
            db.Update(alumno);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{nc}")]
        public async Task<IActionResult> Delete(string nc)
        {
            var existe = await db.Alumnos.AnyAsync(x => x.NumeroControl == nc);
            if (!existe)
                return NotFound();
            db.Remove(new Alumno { NumeroControl = nc });
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("SubirImagen")]
        public async Task<IActionResult> PostImagen([FromForm]Fotografia imagen)
        {
            try
            {
                string urlFoto = "";
                if(imagen.Foto is not null)
                {
                    urlFoto = await almacenador.AlmacenarImagen("Fotos", imagen.Foto);
                }
                return Ok(new {url = urlFoto, nombre = imagen.Foto});
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}