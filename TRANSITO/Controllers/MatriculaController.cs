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
    public class MatriculaController : ControllerBase
    {
        // GET: api/<matriculaController>
        #region propiedades
        private readonly TRANSITOContext _Context;
        #endregion propiedades
        #region construtor
        public MatriculaController(TRANSITOContext context)
        {
            _Context = context;
        }
        #endregion construtor
        #region public metodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTOs>>> Get()
        {
            var matricula = await _Context.Matriculas.Select(x =>
                new MatriculaDTOs
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    FechaExpiracion = x.FechaExpiracion,
                    Activo = x.Activo


                }).ToListAsync();
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }
        }
        #endregion public metodo

        // GET api/<matriculaController>/5
        #region metodo public
        [HttpGet("{Id}")]
        public async Task<ActionResult<MatriculaDTOs>> Get(int Id)
        {
            var matricula = await _Context.Matriculas.Select(x =>
                 new MatriculaDTOs
                 {
                     Id = x.Id,
                     Numero = x.Numero,
                     FechaExpedicion = x.FechaExpedicion,
                     FechaExpiracion = x.FechaExpiracion,
                     Activo = x.Activo


                 }).FirstOrDefaultAsync(x => x.Id == Id);
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(matricula);
            }

        }
        #endregion metodo public

        // POST api/<matriculaController>
        #region metodo public
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculaDTOs matricula)
        {
            var matricul = new Matricula()
            {
                Id = matricula.Id,
                Numero = matricula.Numero,
                FechaExpedicion = matricula.FechaExpedicion,
                FechaExpiracion = matricula.FechaExpiracion,
                Activo = matricula.Activo
            };
            _Context.Matriculas.Add(matricul);
            await _Context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }
        #endregion metodo public

        // PUT api/<matriculaController>/5
        #region metodo public
        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> Put(MatriculaDTOs matricula)
        {
            var matricul = await _Context.Matriculas.FirstOrDefaultAsync(m => m.Id == matricula.Id);
            matricul.Id = matricula.Id;
            matricul.Numero = matricula.Numero;
            matricul.FechaExpedicion = matricula.FechaExpedicion;
            matricul.FechaExpedicion = matricula.FechaExpedicion;
            matricul.Activo = matricula.Activo;

            _Context.Entry(matricul).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        #endregion metodo public

        // DELETE api/<matriculaController>/5
        #region metodo public
        [HttpDelete("{Id}")]
        public async Task<HttpStatusCode> Delete(int Id)
        {
            var matricula = new Matricula()
            {
                Id = Id
            };
            _Context.Matriculas.Attach(matricula);
            _Context.Matriculas.Remove(matricula);
            await _Context.SaveChangesAsync();
            return HttpStatusCode.OK;

        }
        #endregion metodo public
    }
}
