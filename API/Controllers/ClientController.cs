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
    public class ClientController : Controller
    {
        private ICRUD<Client> _crud;
        public ClientController([FromServices] IContext c) {
            _crud = new CRUD<Client>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[HttpPost("test")]
        //public IActionResult test([FromForm] Client p) {
        public IActionResult test([FromBody] Client p)
        {
            return Ok("ok");
        }*/
        [HttpGet("Client/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("Invalid id");
            Client usuario = _crud.Get(id);
            return Ok(usuario ?? new Client());
        }
        [HttpPost("Client")]
        public IActionResult add([FromBody] Client Client)
        {
            var u = Client;
            _crud.Add(Client);
            if (Client.id != 0) return Ok();            
            else return BadRequest();
        }
        [HttpPut("Client")]
        public IActionResult edit([FromBody] Client Client)
        {
            _crud.Update(Client);
            return Ok();
        }
        [HttpGet("Client/all")]
        public IActionResult All()
        {
            return Ok(_crud.All());
        }
        public IActionResult getRange(int from, int to)
        {
            return Ok(_crud.getRange(from, to));
        }
        [HttpDelete("Client/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok();
        }
    }
}
