using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Data.Models;
using FluentValidation;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace sportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PTextDrillController : ControllerBase
    {
        private readonly IPTextDrillService _service;
        private readonly IValidator<PTextDrill> _validator;

        public PTextDrillController(
            IPTextDrillService service,
            IValidator<PTextDrill> validator)
        {
            _service = service;
            _validator = validator;
        }
        [HttpGet("GetByUser")]
        public List<PTextDrill> GetByUser([FromQuery] int userId)
           => _service.GetByUser(userId).Data;

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is required." });

            var result = _service.Get(id);

            if (!result.IsSuccess || result.Data == null)
                return NotFound(new { message = result.Message ?? "Drill not found." });

            return Ok(result.Data);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PTextDrill dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Drill body is required." });

            // FluentValidation
            var validation = _validator.Validate(dto);
            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    error = e.ErrorMessage
                });

                return BadRequest(new
                {
                    message = "Validation failed.",
                    errors
                });
            }

            var result = _service.Add(dto);


            var d = result.Data; 

            return Ok(new
            {
                message = result.Message ?? "Pre text drill created successfully.",
                drill = new
                {
                    d.Id,
                    d.Name,
                    d.Description,
                    d.ExNames,
                    d.ExDurationsSec,
                    d.IsRandomOrder,
                    d.HasBreakBtwExs,
                    d.BreakBtwExsSec,
                    d.RepeatCount,
                    d.HasBreakBtwRepeats,
                    d.BreakBtwRepeatsSec,
                    d.DemonstrationType,
                    d.TotalDurationSec
                }
            });
        }


        [HttpPost("SoftDelete")]
        public IActionResult SoftDelete([FromQuery] int id)
        {
            var result = _service.SoftDelete(id);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPut("Update")]
        public bool Update([FromBody] PTextDrill drill)
             => _service.Update(drill).IsSuccess;


        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _service.SoftDelete(id);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
