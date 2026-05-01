using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace sportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillColorsController : ControllerBase
    {
        private readonly IDrillColorService _service;

        public DrillColorsController(IDrillColorService service) => _service = service;

        [HttpGet("GetColors")]
        public List<DrillColor> GetColors()
            => _service.GetList().Data;

        [HttpGet("GetColor")]
        public DrillColor? GetColor([FromQuery] int id)
            => _service.Get(id).Data;

        [HttpPost("Add")]
        public bool Add([FromBody] DrillColor c)
            => _service.Add(c).IsSuccess;

        [HttpPut("Update")]
        public bool Update([FromBody] DrillColor c)
            => _service.Update(c).IsSuccess;

        [HttpDelete("Delete")]
        public bool Delete([FromQuery] int id)
            => _service.Delete(id).IsSuccess;
    }
}
