using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;

namespace sportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CFocusDrillController : ControllerBase
    {
        private readonly ICFocusDrillService _service;
        private readonly IValidator<CFocusDrill> _validator;

        public CFocusDrillController(
            ICFocusDrillService service,
            IValidator<CFocusDrill> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet("GetByUser")]
        public List<CFocusDrill> GetByUser([FromQuery] int userId)
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
        public IActionResult Add([FromBody] CFocusDrill dto)
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

            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            var d = result.Data;

            return Ok(new
            {
                message = result.Message ?? "Custom Focus drill created successfully.",
                drill = new
                {
                    d.Id,
                    d.UserId,
                    d.Name,
                    d.Description,
                    d.TargetColorCount,
                    d.TargetColors,
                    d.ActionsForTargetColors,
                    d.SwitchIntervalSec,
                    d.TotalDurationSec,
                    d.DifficultyLevel,
                    d.AutoIncreaseDifficulty
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
        public bool Update([FromBody] CFocusDrill drill)
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
