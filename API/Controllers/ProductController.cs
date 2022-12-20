using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Entities._Interface;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API.Controllers
{
    public class ProductController : Controller
    {
        private ICRUD<Product> _crud;
        public ProductController([FromServices] IContext c) {
            _crud = new CRUD<Product>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[HttpPost("test")]
        //public IActionResult test([FromForm] Product p) {
        public IActionResult test([FromBody] Product p)
        {
            return Ok("ok");
        }*/
        [HttpGet("Product/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("Invalid id");
            Product usuario = _crud.Get(id);
            return Ok(usuario ?? new Product());
        }
        [HttpPost("Product")]
        public IActionResult add([FromBody] Product Product)
        {
            var u = Product;
            _crud.Add(Product);
            if (Product.id != 0) return Ok();            
            else return BadRequest();
        }
        [HttpPut("Product")]
        public IActionResult edit([FromBody] Product Product)
        {
            _crud.Update(Product);
            return Ok();
        }
        [HttpGet("Product/all")]
        public IActionResult All()
        {
            return Ok(_crud.All());
        }
        public IActionResult getRange(int from, int to)
        {
            return Ok(_crud.getRange(from, to));
        }
        [HttpDelete("Product/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok();
        }
    }
}
