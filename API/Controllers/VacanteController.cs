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
        public VacanteController() {
            Context c = new Context();
            _crud = new CRUD<Vacante>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Vacante/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("No VacanteId provided");
            Vacante usuario = _crud.Get(id);
            return Ok(usuario);
        }
        [HttpPost("Vacante/add")]
        public IActionResult add([FromBody] Vacante VacanteData)
        {
            _crud.Add(VacanteData);
            return Ok("Ok??");
        }
        [HttpPut("Vacante/update")]
        public IActionResult edit([FromBody] Vacante VacanteData)
        {
            _crud.Update(VacanteData);
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
        [HttpDelete("Vacante/{id?}")]
        public IActionResult remove(int id)
        {
            return Ok("Not implemented!!");
        }

    }
}
