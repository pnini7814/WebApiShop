using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        IOrderServices Services;
        public OrderController(IOrderServices services)
        {
            Services = services;
        }
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            return await Services.GetOrders();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO order = await Services.GetOrderById(id);
            if (order.OrderId == id)
                return Ok(order);
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO order)
        {
            OrderDTO _service = await Services.CreateOrder(order);
            if (_service != null)
                return CreatedAtAction(nameof(Get), new { Id = _service.OrderId }, _service);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderDTO order)
        {
            try
            {
                await Services.UpdateOrder(id, order);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}   

