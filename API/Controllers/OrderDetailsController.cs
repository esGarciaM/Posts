using Data.Interface;
using Data;
using Entities._Entities;
using Entities._Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ICRUD<OrderDetails> _crud;
        private IContext _c;
        public OrderDetailsController([FromServices] IContext c)
        {
            _crud = new CRUD<OrderDetails>(c);
            _c = c;
        }
        [HttpPost("OrderDetails")]
        public IActionResult addOrderDetails([FromBody] OrderDetails od)
        {
            if(od is null) return BadRequest("valide la estructura de la informacion envada");
            int orderId = od.OrderID;
            var ocrud = new CRUD<Order>(_c);
            Order o = ocrud.Get(orderId);
            if(o is null) return NotFound("Numero de orden no encontrado, favor de verificarlo");
            _c.Instance.Attach(o);
            od.Order = o;
            _crud.Add(od);
            return Ok("Elemento insertado correctamente");
        }
        [HttpGet("emtyOrderDetails")]
        public IActionResult emptyOrderDetails() {
            OrderDetails od = new OrderDetails();
            return Ok(od);
        }
        [HttpGet("OrderDetails/{orderID}")]
        public IActionResult getOrderDetails(int orderID) {
            var e = _crud.GetEntity();
            IEnumerable<OrderDetails> od = e.Where(x => x.OrderID == orderID).ToList();
            if(od is null) return NotFound(od);
            return Ok(od);
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
