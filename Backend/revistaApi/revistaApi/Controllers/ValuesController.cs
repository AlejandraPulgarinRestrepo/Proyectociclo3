using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;//libreria cor
using System.Text.Json;
using revistaApi.Modelos;
//Controlador que se encarga de los autores


namespace revistaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//libreria cors
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{ced}/{clave}")]
        public string Get(string ced, string clave)
        {
            Autor User = new Autor(ced, "", "", "", "", clave, "", 0);
            User.conectar();
            var mensaje = User.autenticar();
            return mensaje;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] JsonElement datos)
        {
            String ced = datos.GetProperty("ced").ToString();
            String nom = datos.GetProperty("nom").ToString();
            String nom2 = datos.GetProperty("nom2").ToString();
            String ap = datos.GetProperty("ap").ToString();
            String ap2 = datos.GetProperty("ap2").ToString();
            String clave = datos.GetProperty("clave").ToString();
            String email = datos.GetProperty("email").ToString();
            int edad = datos.GetProperty("edad").GetInt32();
            Autor User = new Autor(ced, nom, nom2, ap, ap2, clave, email, edad);
            User.conectar();
            var mensaje = User.ingresar();
            return mensaje;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}