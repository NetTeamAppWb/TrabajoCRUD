using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCenterAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/Category  este get sirve para leer todo 
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Category/5  este get solo leera del id que le ingresemos
        [HttpGet("{id}", Name = "GetCategory")]
        public Category Get(int id)
        {
            Category category = new Category();
            category.id = id;
            category.Name = "Name " + id.ToString();
            category.Count = 10;

            return category;
        }

        // POST: api/Category
        [HttpPost]
        public StatusCodeResult Post([FromBody] Category category)
        {
            //Status code se usa para dar respuestas del servidor al usuario (se debe cambiar el void por StatusCodeResult)
            if(category.Name == "")
                return StatusCode(400); //error cuando el nombre es vacio, ERROR CLIENT
            return StatusCode(201);  //todo correcto 
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
