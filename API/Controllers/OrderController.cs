using Data.Interface;
using Data;
using Entities._Entities;
using Entities._Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : Controller
    {
        private ICRUD<Order> _crud;
        public OrderController([FromServices] IContext c)
        {
            _crud = new CRUD<Order>(c);
        }
        [HttpPost("Order")]
        public IActionResult addOrder([FromBody] Order order)
        {
            _crud.Add(order);
            return Ok("ok");
        }



        /*public IActionResult Index()
        {
            return View();
        }
        [HttpGet("User/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("Invalid id");
            User usuario = _crud.Get(id);
            return Ok(usuario ?? new User());
        }
        [HttpPost("User")]
        public IActionResult add([FromBody] User user)
        {
            var u = user;
            _crud.Add(user);
            if (user.id != 0) return Ok();
            else return BadRequest();
        }
        [HttpPut("User")]
        public IActionResult edit([FromBody] User user)
        {
            _crud.Update(user);
            return Ok();
        }
        [HttpGet("User/all")]
        public IActionResult All()
        {
            return Ok(_crud.All());
        }
        public IActionResult getRange(int from, int to)
        {
            return Ok(_crud.getRange(from, to));
        }
        [HttpDelete("User/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok();
        }*/
    }
}
