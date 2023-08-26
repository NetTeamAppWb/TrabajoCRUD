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
        private static List<Register> _registerdata = new List<Register>
        {
            new Register {id= 1, Name= "Nelida", Tipe= "emprendedor"},
            new Register {id=2, Name="Alex",  Tipe= "consumidor"},
            new Register {id=3, Name="Jessica",  Tipe= "consumidor"},
            new Register {id=4, Name="Wilman",  Tipe= "emprendedor"}
        };
        
        // GET: api/Register / Hecho por CAMILA
        [HttpGet]
        public IEnumerable<Register> Get()
        {
            return _registerdata;
        }

        // GET: api/Register/5  /Hecho por Blas
        [HttpGet("{id}", Name = "GetRegister")]
        public Register Get(int id)
        {
            Register register = new Register();
            register.id = id;

            // Generar un número aleatorio entre 0 y la cantidad de elementos en _registerdata
            Random random = new Random();
            int randomIndex = random.Next(0, _registerdata.Count);

            // Obtener el elemento aleatorio de la lista
            Register randomRegister = _registerdata[randomIndex];

            // Asignar el nombre y tipo aleatorios al registro
            register.Name = randomRegister.Name;
            register.Tipe = randomRegister.Tipe;

            return register;
        }

        // POST: api/Register   /Hecho por Jose
        [HttpPost]
        public IActionResult Post([FromBody] Register register)
        {
            if (register == null)
            {
                return BadRequest();
            }

            Register newRegister = new Register
            {
                Name = register.Name,
                Tipe = register.Tipe
            };
            return Ok();
        }

        // PUT: api/Register/5   /Hecho por JesusLazo
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


        // DELETE: api/Register/5   /Hecho por Frezzia
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(Register register)
        {
            try
            {
                if (register.id == 0)
                    return StatusCode(400);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
