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
        public EntrevistaController([FromServices] Context c)
        {
            //Context c = new Context();
            _crud = new CRUD<Entrevista>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Entrevista/test")]
        public IActionResult test([FromForm] Entrevista p)
        {
            return Ok(p);
        }
        [HttpGet("Entrevista/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No EntrevistaId provided");
            Entrevista usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("Entrevista/add")]
        public IActionResult add([FromForm] Entrevista EntrevistaData)
        {
            _crud.Add(EntrevistaData);
            return Ok("Ok??");
        }
        [HttpPut("Entrevista/update")]
        public IActionResult edit([FromForm] Entrevista EntrevistaData)
        {
            _crud.Update(EntrevistaData);
            return Ok();
        }
        [HttpGet("Entrevista/all")]
        public IActionResult All()
        {
            IEnumerable<Entrevista> p = _crud.All();
            return Ok(p);
        }
        public IActionResult getRange()
        {
            return Ok("Not implemented!!");
        }
        [HttpDelete("Entrevista/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok("Not implemented!!");
        }

    }
}
