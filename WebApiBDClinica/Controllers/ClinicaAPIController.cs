using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiBDClinica.Models;
//using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiBDClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaAPIController : ControllerBase
    {
        private readonly BDCLINICA_WEBAPI_REACTContext bd;

        // ctor
        public ClinicaAPIController(BDCLINICA_WEBAPI_REACTContext ctx)
        {
            bd = ctx;
        }

        // GET: api/<ClinicaAPIController>
        [HttpGet("GetCitasAnio/{anio}")]
        public List<PA_CITAS_ANIO> GetCitasAnio(int anio)
        {
            var listado = bd.PA_CITAS_ANIO
                            .FromSqlRaw<PA_CITAS_ANIO>(
                                "EXECUTE PA_CITAS_ANIO {0}", anio)
                            .ToList();

            return listado;
        }

        // GET api/<ClinicaAPIController>/5
        [HttpGet("GetMedicosEsp/{codesp}")]
        public List<PA_MEDICOS_ESPECIALIDAD> GetMedicosEsp(string codesp)
        {
            var listado = bd.PA_MEDICOS_ESPECIALIDAD
                            .FromSqlRaw<PA_MEDICOS_ESPECIALIDAD>(
                                "EXECUTE PA_MEDICOS_ESPECIALIDAD {0}", codesp)
                            .ToList();

            return listado;
        }

        [HttpGet("GetEspecialidades")]
        public List<Especialidad> GetEspecialidades()
        {
            var listado = bd.Especialidads.ToList();

            return listado;
        }


        // POST api/<ClinicaAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClinicaAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClinicaAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
