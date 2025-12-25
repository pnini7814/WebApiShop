using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics.Metrics;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs;

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
        public async Task<IEnumerable<UserDTO>> Get()
        {
            
            return await Services.GetUsers() ;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            UserDTO user=await Services.GetUserById(id);
            if (user.UserId==id)
                        return Ok(user);
            return NotFound();

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            //check password
            //if bad
            //return BadRequest("password in low")
            
            UserDTO _service= await Services.CreateUser(user);
            if (_service == null)
                return BadRequest();
            return Ok(user);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Post1([FromBody] LoginUserDTO loggedUser)
        {
            UserDTO? user = await Services.login(loggedUser);
            if (user!=null)
                        return CreatedAtAction(nameof(Get), new { user.UserId }, user);
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDTO loggedUser)
        {
            try
            {
                await Services.UpdateUser(id, loggedUser);
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


