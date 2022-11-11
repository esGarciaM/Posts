using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VacanteController : Controller
    {
        private ICRUD<Vacante> _crud;
        public VacanteController([FromServices] Context c)
        {
            //Context c = new Context();
            _crud = new CRUD<Vacante>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Vacante/test")]
        public IActionResult test([FromForm] Vacante p)
        {
            return Ok(p);
        }
        [HttpGet("Vacante/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No VacanteId provided");
            Vacante usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("Vacante/add")]
        public IActionResult add([FromForm] Vacante VacanteData)
        {
            _crud.Add(VacanteData);
            return Ok("Ok??");
        }
        [HttpPut("Vacante/update")]
        public IActionResult edit([FromForm] Vacante VacanteData)
        {
            _crud.Update(VacanteData);
            return Ok();
        }
        [HttpGet("Vacante/all")]
        public IActionResult All()
        {
            IEnumerable<Vacante> p = _crud.All();
            return Ok(p);
        }
        public IActionResult getRange()
        {
            return Ok("Not implemented!!");
        }
        [HttpDelete("Vacante/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok("Not implemented!!");
        }

    }
}
