using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics.Metrics;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IuserServices Services;
        public UsersController(IuserServices services)
        {
            this.Services = services;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user=Services.GetUserById(id);
            if (user.Id==id)
                        return Ok(user);
            return NotFound();

        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            //check password
            //if bad
            //return BadRequest("password in low")
            
            User _service= Services.CreateUser(user);
            if (_service == null)
                return BadRequest();
            return Ok(user);

        }

        [HttpPost("login")]
        public ActionResult<User> Post1([FromBody] User loggedUser)
        {
            User? user = Services.login(loggedUser);
            if (user!=null)
                        return CreatedAtAction(nameof(Get), new { user.Id }, user);
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User loggedUser)
        {
            try
            {
                Services.UpdateUser(id, loggedUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


