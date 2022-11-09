using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EntrevistaController : Controller
    {
        private ICRUD<Entrevista> _crud;
        public EntrevistaController() {
            Context c = new Context();
            _crud = new CRUD<Entrevista>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Entrevista/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No EntrevistaId provided");
            Entrevista usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("Entrevista/add")]
        public IActionResult add([FromBody] Entrevista EntrevistaData)
        {
            _crud.Add(EntrevistaData);
            return Ok("Ok??");
        }
        [HttpPut("Entrevista/update")]
        public IActionResult edit([FromBody] Entrevista EntrevistaData)
        {
            _crud.Update(EntrevistaData);
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
        [HttpDelete("Entrevistav/{id?}")]
        public IActionResult remove(int id)
        {
            return Ok("Not implemented!!");
        }

    }
}
