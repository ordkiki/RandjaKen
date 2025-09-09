using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Features.Users.LoginUser;
using Ranjaken.Domain.Exceptions;
using RanjaKen.Api.Model;

namespace RanjaKen.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        #region Cre 
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LoginUserCommand request)
        {
            //if (request == null) return BadRequest(new ApiException("Invalid request", 400, false));
            UserDto result = await _mediator.Send(request);
            return Ok(new ApiResponse<UserDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "you are connected successfully",
                Meta = null
            });
        }
        #endregion
    }
}