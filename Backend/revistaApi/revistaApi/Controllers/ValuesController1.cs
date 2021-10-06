using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;//libreria cor
using System.Text.Json;
using revistaApi.Modelos;
//Controlador que se encarga de los articulos

namespace revistaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//libreria cors
    public class ValuesController1 : ControllerBase
    {
        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public string Post([FromBody] JsonElement datos)
        {
            //DateTime dateTime = DateTime.UtcNow.Date;
            String ced = datos.GetProperty("ced").ToString();
            String titulo = datos.GetProperty("titulo").ToString();
            String descripcion = datos.GetProperty("descripcion").ToString();
            String contenido = datos.GetProperty("contenido").ToString();
            //String fecha = dateTime.ToString("yyyy/MM/dd");
            String fecha = datos.GetProperty("fecha").ToString();
            Articulo User = new Articulo(ced, titulo, descripcion, fecha, contenido, false);
            User.conectar();
            var mensaje = User.ingresar();
            return mensaje;
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{ced}/{titulo}")]
        public string Delete(string ced, string titulo)
        {
            Articulo User = new Articulo(ced, titulo, "", "", "", false);
            User.conectar();
            var mensaje = User.borrar();
            return mensaje;
        }
    }
}
