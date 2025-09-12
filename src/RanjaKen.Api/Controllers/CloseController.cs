using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Features.Closes;
using Ranjaken.Application.Features.Users.LoginUser;
using Ranjaken.Domain.Exceptions;
using RanjaKen.Api.Model;

namespace RanjaKen.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CloseController(IMediator _mediator) : ControllerBase
    {
        #region GetDate 
        [HttpGet("dates")]
        public async Task<IActionResult> GetDates()
        {
            GetDateQuery query = new ();
            GetDateResponse result = await _mediator.Send(query);

            return Ok(new ApiResponse<GetDateResponse>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "Dates retrieved successfully",
                Meta = null
            });
        }
        #endregion
    }
}