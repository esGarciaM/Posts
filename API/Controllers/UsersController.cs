using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Route("user")]
    public class UsersController : Controller
    {
        private ICRUD<User> _crud;
        public UsersController() {
            Context c = new Context();
            _crud = new CRUD<User>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("user/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No userId provided");
            User usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("user/add")]
        public IActionResult add([FromBody] User userData)
        {
            _crud.Add(userData);
            return Ok("Ok??");
        }
        [HttpPut("user/update")]
        public IActionResult edit([FromBody] User userData)
        {
            _crud.Update(userData);
            return Ok();
        }
        public IActionResult All()
        {
            return Ok("Not implemented!!");
        }
        public IActionResult getRange()
        {
            return Ok("Not implemented!!");
        }
        [HttpDelete("user/{id?}")]
        public IActionResult remove(int id)
        {
            return Ok("Not implemented!!");
        }

    }
}
