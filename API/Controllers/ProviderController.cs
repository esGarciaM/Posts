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
    public class ProviderController : Controller
    {
        private ICRUD<Provider> _crud;
        public ProviderController([FromServices] IContext c) {
            _crud = new CRUD<Provider>(c);
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[HttpPost("test")]
        //public IActionResult test([FromForm] Provider p) {
        public IActionResult test([FromBody] Provider p)
        {
            return Ok("ok");
        }*/
        [HttpGet("Provider/{id}")]
        public IActionResult get(int id)
        {
            if (id == 0) return BadRequest("Invalid id");
            Provider usuario = _crud.Get(id);
            return Ok(usuario ?? new Provider());
        }
        [HttpPost("Provider")]
        public IActionResult add([FromBody] Provider Provider)
        {
            var u = Provider;
            _crud.Add(Provider);
            if (Provider.id != 0) return Ok();            
            else return BadRequest();
        }
        [HttpPut("Provider")]
        public IActionResult edit([FromBody] Provider Provider)
        {
            _crud.Update(Provider);
            return Ok();
        }
        [HttpGet("Provider/all")]
        public IActionResult All()
        {
            return Ok(_crud.All());
        }
        public IActionResult getRange(int from, int to)
        {
            return Ok(_crud.getRange(from, to));
        }
        [HttpDelete("Provider/{id?}")]
        public IActionResult remove(int id)
        {
            _crud.Delete(id);
            return Ok();
        }
    }
}
