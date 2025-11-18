using Entities;
using Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {

        IpasswordServic PasswordServic;
        public PasswordController(IpasswordServic service)
        {
            this.PasswordServic = service;
        }
        //passwordServic PasswordServic = new passwordServic();

        // GET: api/<PasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        // POST api/<PasswordController>
        public ActionResult<password> Post([FromBody] string password)
        {
            password password1 = PasswordServic.PasswordHardness(password);
            if (password1.Level < 3) return BadRequest();
            return Ok(password1);
        }

        [HttpPost("check")]
        public password Post1([FromBody] string password)
        {
            password password1 = PasswordServic.PasswordHardness(password);
            return password1;
        }

        // PUT api/<PasswordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
