using EntitiFreWork01.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TRANSITO.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TRANSITO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionesController : ControllerBase
    {
        // GET: api/<SancionesController>
        #region propiedades
        private readonly TRANSITOContext _Context;
        #endregion propiedades
        #region construtor
        public SancionesController(TRANSITOContext context)
        {
            _Context = context;
        }
        #endregion construtor
        #region public metodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTOs>>> Get()
        {
            var sancion = await _Context.Sanciones.Select(x =>
                new SancionesDTOs
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    ConductorId = x.ConductorId

                }).ToListAsync();
            if (sancion == null)
            {
                return NotFound();
            }
            else
            {
                return sancion;
            }

        }
        #endregion public metodo

        // GET api/<SancionesController>/5
        #region metodo public
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTOs>> Get(int id)
        {
            var sancion = await _Context.Sanciones.Select(x =>
                 new SancionesDTOs
                 {
                     Id = x.Id,
                     Fecha = x.Fecha,
                     ConductorId = x.ConductorId

                 }).FirstOrDefaultAsync(x => x.Id == id);
            if (sancion == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(sancion);
            }

        }
        #endregion metodo public

        // POST api/<SancionesController>
        #region metodo public
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTOs sanciones)
        {
            var sancion = new Sancione()
            {
                Id = sanciones.Id,
                Fecha = sanciones.Fecha,
                ConductorId = sanciones.ConductorId,
               
            };
            _Context.Sanciones.Add(sancion);
            await _Context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }
        #endregion metodo public

        // PUT api/<SancionesController>/5
        #region metodo public
        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> Put(SancionesDTOs sanciones)
        {
            var sancion = await _Context.Sanciones.FirstOrDefaultAsync(s => s.Id == sanciones.Id);
            sancion.Id = sanciones.Id;
            sancion.Fecha = sanciones.Fecha;
            sancion.ConductorId = sanciones.ConductorId;
          

            _Context.Entry(sancion).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        #endregion metodo public

        // DELETE api/<SancionesController>/5
        #region metodo public
        [HttpDelete("{Id}")]
        public async Task<HttpStatusCode> Delete(int Id)
        {
            var sancion = new Sancione()
            {
                Id = Id
            };
            _Context.Sanciones.Attach(sancion);
            _Context.Sanciones.Remove(sancion);
            await _Context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion metodo public
    }
}
