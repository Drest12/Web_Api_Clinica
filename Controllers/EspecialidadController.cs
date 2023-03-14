using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using WebApiBDCLINICA.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiBDCLINICA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly BDCLINICA2022Context bd;
        public EspecialidadController(BDCLINICA2022Context obj)
        {
            bd = obj;
        }

        // GET: api/<EspecialidadController>
        [HttpGet]
        public IEnumerable<Especialidad> Get()  // lista de especialidades
        {
            //var listado = bd.Especialidads.ToList();
            //return listado;
            
            return bd.Especialidads.ToList();
        }

        // GET api/<EspecialidadController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var esp = bd.Especialidads.Find(id);
            // si no se encuentra la especialidad
            if (esp == null)
                return BadRequest("Error, Especialidad No Encontrada");
            
            return Ok(esp);

            //return Ok(bd.Especialidads.Find(id));
        }

        // POST api/<EspecialidadController>
        [HttpPost]
        public ActionResult Post([FromBody] Especialidad objEsp)
        {
            try
            {
                // buscar la especialidad por el codigo
                var esp = bd.Especialidads.Find(objEsp.Codesp);
                // si codigo es encontrado
                if (esp != null)
                    return BadRequest("Error, Especialidad ya Existe");
                // 
                bd.Especialidads.Add(objEsp);
                bd.SaveChanges();
                //
                return Ok(objEsp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<EspecialidadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Especialidad objEsp)
        {
            try
            {
                // buscar la especialidad por el codigo
                //var esp = bd.Especialidads.Find(id); //objEsp.Codesp
                // si la especialidad no existe
                //if (esp == null)
                //   return BadRequest("Error, la Especialidad NO EXISTE");

                // actualizando versión 1
                //esp.Nomesp = objEsp.Nomesp;
                //esp.Costo = objEsp.Costo;

                // actualizando versión 2 (EF)
                objEsp.Codesp = id;
                bd.Entry(objEsp).State = EntityState.Modified;
                
                bd.SaveChanges();
                //
                return Ok(objEsp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EspecialidadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var esp = bd.Especialidads.Find(id);
                //
                if (esp == null)
                    return BadRequest("Error, Especialidad NO Encontrada");
                //
                bd.Especialidads.Remove(esp);
                bd.SaveChanges();
                //
                return Ok(esp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
