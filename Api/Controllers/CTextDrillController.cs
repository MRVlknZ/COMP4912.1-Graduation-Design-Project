using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace sportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTextDrillController : ControllerBase
    {
        private readonly ICTextDrillService _service;
        private readonly IValidator<CTextDrill> _validator;

        public CTextDrillController(
            ICTextDrillService service,
            IValidator<CTextDrill> validator)
        {
            _service = service;
            _validator = validator;
        }

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

        [HttpGet("GetByUser")]
        public List<CTextDrill> GetByUser([FromQuery] int userId)
           => _service.GetByUser(userId).Data;


        [HttpPost("Add")]
        public IActionResult Add([FromBody] CTextDrill dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Drill body is required." });

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
                message = result.Message ?? "Custom text drill created successfully.",
                drill = new
                {
                    d.Id,
                    d.Name,
                    d.Description,
                    d.ExNames,
                    d.ExDurationsSec,
                    d.IsSequential,
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




        [HttpPut("Update")]
        public bool Update([FromBody] CTextDrill drill)
            => _service.Update(drill).IsSuccess;

        [HttpDelete("Delete")]
        public bool Delete([FromQuery] int id)
            => _service.Delete(id).IsSuccess;

        [HttpPost("SoftDelete")]
        public IActionResult SoftDelete([FromQuery] int id)
        {
            var result = _service.SoftDelete(id);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
