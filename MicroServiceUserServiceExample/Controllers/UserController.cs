using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServiceUserServiceExample.Database;
using MicroServiceUserServiceExample.Database.Entities;
using Microsoft.AspNetCore.Http;

namespace MicroServiceUserServiceExample.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        DatabaseContext db;

        public UserController()
        {
            db = new DatabaseContext();
        }

        // GET: api/<userController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // GET: api/<UserController>/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        //POST: api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
