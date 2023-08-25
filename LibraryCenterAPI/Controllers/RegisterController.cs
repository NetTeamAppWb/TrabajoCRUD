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
    public class RegisterController : ControllerBase
    {
        // GET: api/Register
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        [HttpGet("{id}", Name = "GetRegister")]
        public Register Get(int id)
        {
            Register register = new Register();
            register.id = id;
            register.Name = "Name";
            register.Tipe = "Tipe";
            return register;
        }

        // POST: api/Register
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Register/5  JesusLazo
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Register register)
        {
            if (register.id > 0 || string.IsNullOrWhiteSpace(register.Name) || //nombre no vacio
                (register.Tipe != "emprendedor" && register.Tipe != "consumidor"))
            {
                return BadRequest();  // 400 Bad Request
            }
            return Ok();  // 200 OK
        }


        // DELETE: api/Register/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
