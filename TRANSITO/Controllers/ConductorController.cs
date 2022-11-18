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
    public class ConductorController : ControllerBase
    {

        // GET: api/<ConductorController>
        #region propiedades
        private readonly TRANSITOContext _Context;
        #endregion propiedades  
        #region construtor
        public ConductorController(TRANSITOContext context)
        {
            _Context = context;
        }
        #endregion construtor
        #region public metodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTOs>>> Get()
        {
            var conduct = await _Context.Conductors.Select(x =>
                new ConductorDTOs
                {
                    Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    MatriculaId = x.MatriculaId

                }).ToListAsync();
            if (conduct == null)
            {
                return NotFound();
            }
            else
            {
                return conduct;
            }

        }
        #endregion public metodo

        // GET api/<ConductorController>/5
        #region metodo public
        [HttpGet("{Id}")]
        public async Task<ActionResult<ConductorDTOs>> Get(int Id)
        {
            var conductor = await _Context.Conductors.Select(x =>
            new ConductorDTOs
            {
                Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                MatriculaId = x.MatriculaId

            }).FirstOrDefaultAsync(x => x.Id == Id);
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(conductor);
            }

        }
        #endregion metodo public

        // POST api/<ConductorController>
        #region metodo public
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTOs conductor)
        {
            var conduct = new Conductor()
            {
                Id = conductor.Id,
                Identificacion = conductor.Identificacion,
                Nombre = conductor.Nombre,
                Apellidos = conductor.Apellidos,
                Direccion = conductor.Direccion,
                Telefono = conductor.Telefono,
                MatriculaId = conductor.MatriculaId
            };
            _Context.Conductors.Add(conduct);
            await _Context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }
        #endregion metodo public

        // PUT api/<ConductorController>/5
        #region metodo public
        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> Put(ConductorDTOs conductor)
        {
            var conduct = await _Context.Conductors.FirstOrDefaultAsync(c => c.Id == conductor.Id);
            conduct.Id = conductor.Id;
            conduct.Identificacion = conductor.Identificacion;
            conduct.Nombre = conductor.Nombre;
            conduct.Apellidos = conductor.Apellidos;
            conduct.Direccion = conductor.Direccion;
            conduct.Telefono = conductor.Telefono;
            conduct.MatriculaId = conductor.MatriculaId;

            _Context.Entry(conduct).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        #endregion metodo public

        // DELETE api/<ConductorController>/5
        #region metodo public
        [HttpDelete("{Id}")]
        public async Task<HttpStatusCode> Delete(int Id)
        {
            var conduct = new Conductor()
            {
                Id = Id
            };
            _Context.Conductors.Attach(conduct);
            _Context.Conductors.Remove(conduct);
            await _Context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion metodo public

    }
}
