using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProspectoController : Controller
    {
        private ICRUD<Prospecto> _crud;
        public ProspectoController() {
            Context c = new Context();
            _crud = new CRUD<Prospecto>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Prospecto/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No ProspectoId provided");
            Prospecto usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("Prospecto/add")]
        public IActionResult add([FromBody] Prospecto ProspectoData)
        {
            _crud.Add(ProspectoData);
            return Ok("Ok??");
        }
        [HttpPut("Prospecto/update")]
        public IActionResult edit([FromBody] Prospecto ProspectoData)
        {
            _crud.Update(ProspectoData);
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
        [HttpDelete("Prospecto/{id?}")]
        public IActionResult remove(int id)
        {
            return Ok("Not implemented!!");
        }

    }
}
