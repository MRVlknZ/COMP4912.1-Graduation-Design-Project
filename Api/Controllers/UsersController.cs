using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace sportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IValidator<User> _userValidator;

        public UsersController(IUserService service, IValidator<User> userValidator)
        {
            _service = service;
            _userValidator = userValidator;
        }

        [HttpGet("GetUsers")]
        public List<User> GetUsers()
            => _service.GetList().Data;

        [HttpGet("GetActiveUsers")]
        public List<User> GetActiveUsers()
            => _service.GetActive().Data;

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest(new { message = "User body is required." });

            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new
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

            var result = _service.Add(user);

            if (!result.IsSuccess)
            {

                return BadRequest(new
                {
                    message = result.Message
                });
            }

            return Ok(new
            {
                message = result.Message,
                user = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email
                }
            });
        }
        [HttpPut("UpdateUser")]
        public bool UpdateUser([FromBody] User user)
            => _service.Update(user).IsSuccess;

        [HttpDelete("DeleteUser")]
        public bool DeleteUser([FromQuery] int id)
            => _service.Delete(id).IsSuccess;

        [HttpPost("Ban")]
        public bool Ban([FromQuery] int userId)
            => _service.Ban(userId).IsSuccess;

        [HttpPost("Unban")]
        public bool Unban([FromQuery] int userId)
            => _service.Unban(userId).IsSuccess;
    }
}
