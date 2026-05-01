using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;

namespace sportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CColorDrillController : ControllerBase
    {
        private readonly ICColorDrillService _service;
        private readonly IValidator<CColorDrill> _validator;

        public CColorDrillController(
            ICColorDrillService service,
            IValidator<CColorDrill> validator)
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
        public List<CColorDrill> GetByUser([FromQuery] int userId)
           => _service.GetByUser(userId).Data;

        [HttpPost("Add")]
        public IActionResult Add([FromBody] CColorDrill dto)
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
                message = result.Message,
                drill = new
                {
                    d.Id,
                    d.Name,
                    d.Description,
                    d.TotalDurationSec,
                    d.ColorCount,
                    d.SelectedColorIds,
                    d.SwitchIntervalSec,
                    d.IsRandomOrder,
                    d.DifficultyLevel,
                    d.ActionsPerColor
                }
            });
        }

        [HttpPut("Update")]
        public bool Update([FromBody] CColorDrill drill)
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
