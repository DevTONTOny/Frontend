using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.dto;
using WebApi.Models;
using AutoMapper;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Carreras")]
    public class CarrerasController : ControllerBase
    {
        private readonly DbEscuelaContext db;

        private readonly IMapper mapper;

        public CarrerasController(DbEscuelaContext context, IMapper mapper)
        {
            this.db = context;
            this.mapper = mapper;
        }

        /* <-- Comenta o borra esto
            [HttpGet] 
            public async Task<List<Carrera>> getCarrerar()
            {
                DbEscuelaContext db = new DbEscuelaContext();
                return await db.Carreras.ToListAsync();
            }
            */

        [HttpGet] // <-- Deja solo este
        public async Task<List<CarrerasDTO>> get()
        {
            var carreras = await db.Carreras.ToListAsync();
            return mapper.Map<List<CarrerasDTO>>(carreras);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarrerasDTOCrear carrerasDTO)
        {
            var carrera = mapper.Map<Carrera>(carrerasDTO);
            await db.Carreras.AddAsync(carrera);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> put(int id, [FromBody] CarrerasDTOCrear carreraDTO)
        {
            var existe = await db.Carreras.AnyAsync(x => x.Id == id);
            if (existe == false)
            {
                return NotFound();
            }
            var carrera = mapper.Map<Carrera>(carreraDTO);
            carrera.Id = (short)id;
            db.Update(carrera);
            await db.SaveChangesAsync();
            return NoContent();
        }   

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await db.Carreras.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound();
            db.Remove(new Carrera { Id = (short)id });
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}