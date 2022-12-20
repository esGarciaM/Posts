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
    public class UserController : Controller
    {
        private ICRUD<User> _crud;
        public UserController([FromServices] IContext c) {
            _crud = new CRUD<User>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[HttpPost("test")]
        //public IActionResult test([FromForm] User p) {
        public IActionResult test([FromBody] User p)
        {
            return Ok("ok");
        }*/
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
        }
    }
}
