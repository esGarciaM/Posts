using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API.Controllers
{
    public class ProspectoController : Controller
    {
        private ICRUD<Prospecto> _crud;
        public ProspectoController([FromServices] Context c) {
            
            
            //Context c = new Context();
            _crud = new CRUD<Prospecto>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Prospecto/test")]
        public IActionResult test([FromForm] Prospecto p) {
            return Ok(p);
        }
        [HttpGet("Prospecto/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No ProspectoId provided");
            Prospecto usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("Prospecto/add")]
        public IActionResult add([FromForm] Prospecto ProspectoData)
        {
            _crud.Add(ProspectoData);
            return Ok("Ok??");
        }
        [HttpPut("Prospecto/update")]
        public IActionResult edit([FromForm] Prospecto ProspectoData)
        {
            _crud.Update(ProspectoData);
            return Ok();
        }
        [HttpGet("Prospecto/all")]
        public IActionResult All()
        {
            IEnumerable<Prospecto> p = _crud.All();
            return Ok(p);
        }
        public IActionResult getRange()
        {
            return Ok("Not implemented!!");
        }
        [HttpDelete("Prospecto/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok("Not implemented!!");
        }

    }
}
