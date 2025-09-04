using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Features.Players.Query.GetPlayerById;
using Ranjaken.Application.Features.Users.Command.CreatePlayer;
using Ranjaken.Application.Features.Users.Command.DeletePlayer;
using Ranjaken.Application.Features.Users.Query.GetAllPlayer;
using RanjaKen.Api.Model;

namespace RanjaKen.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/")]
    public class PlayerController(IMediator _mediator) : ControllerBase
    {
        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePlayerCommand request)
        {
            PlayerDto result = await _mediator.Send(new CreatePlayerCommand
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Pseudo = request.Pseudo,
                Age = request.Age,
                Size = request.Size,
                Avatar = request.Avatar,
                TeamId = request.TeamId,
                Position = request.Position,
            });
            return Ok(new ApiResponse<PlayerDto>
            {
                Success = true,
                Code = StatusCodes.Status201Created,
                Data = result,
                Message = "created with success",
                Meta = null
            });
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid? PlayerId)
        {
            await _mediator.Send(new DeletePlayerCommand(PlayerId));
            return Ok(new ApiResponse<PlayerDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = null,
                Message = "Delete with  success",
                Meta = null
            });
        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] GetAllPlayerQuery? request)
        {
            GetAllPlayerResponse result = await _mediator.Send(new GetAllPlayerQuery()
            {
                Search = request?.Search,
                Page = request.Page,
                Limit = request?.Limit
            });
            return Ok(new ApiResponse<List<PlayerDto>>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result.Data.ToList(),
                Message = "retrieved with success",
                Meta = null
            });
        }
        #endregion

        #region GetById
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid? Id)
        {
            var result = await _mediator.Send(new GetPlayerByIdQuery(Id));
            return Ok(new ApiResponse<PlayerDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "retrieved with success",
                Meta = null
            });
        }
        #endregion

    }
}
