using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Features.Players.Query;
using Ranjaken.Application.Features.Players.Query.GetPlayerById;
using Ranjaken.Application.Features.Users.Command.CreatePlayer;
using Ranjaken.Application.Features.Users.Command.DeletePlayer;
using Ranjaken.Application.Features.Users.Command.UpdatePlayer;
using Ranjaken.Application.Features.Users.Query.GetAllPlayer;
using Ranjaken.Domain.Exceptions;
using RanjaKen.Api.Model;

namespace RanjaKen.Api.Controllers
{
    
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PlayerController(IMediator _mediator) : ControllerBase
    {
        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePlayerCommand request)
        {
            if (request == null) throw new ApiException("Invalid request", 400, false);
            PlayerDto result = await _mediator.Send(request);
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

        #region Update
        [HttpPut("{PLayerId}")]
        public async Task<IActionResult> Update([FromRoute]Guid PlayerId, [FromForm] UpdatePlayerRequest request)
        {
            PlayerDto result = await _mediator.Send(new UpdatePlayercommand
            {
                Id = PlayerId,  
                LastName = request.LastName,
                FirstName = request.FirstName,
                Pseudo = request.Pseudo,
                BirthDate = request.BirthDate,
                Size = request.Size,
                Avatar = request.Avatar,
                Idole = request.Idole,
                Position = request.Position,
            });
            return Ok(new ApiResponse<PlayerDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "created with success",
                Meta = null
            });
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid PlayerId)
        {
            await _mediator.Send(new DeletePlayerCommand(PlayerId));
            return Ok(new ApiResponse<PlayerDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = null,
                Message = "Delete with success",
                Meta = null
            });
        }
        #endregion


        [HttpGet("export")]
        public async Task<IActionResult> Export([FromQuery] string? search, [FromQuery] string? teamName)
        {
            byte[]? fileBytes = await _mediator.Send(new ExportExcelQuery
            {
                Search = search,
                TeamName = teamName
            });

            return File(fileBytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Players.xlsx");
        }
        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] GetAllPlayerQuery request)
        {
            GetAllPlayerResponse result = await _mediator.Send(request);
            return Ok(new ApiResponse<IEnumerable<PlayerDto>>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result.Data,
                Message = "retrieved with success",
                Meta = new Meta
                {
                    Limit = request.Limit,
                    Page = request.Page,
                    Total = result.Total,
                    TotalPage = result.TotalPage
                }
            });
        }
        #endregion

        #region GetById
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid? Id)
        {
            PlayerDto result = await _mediator.Send(new GetPlayerByIdQuery(Id));
            return Ok(new ApiResponse<PlayerDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = result == null ? "no player found" : "retrieved with success",
                Meta = null
            });
        }
        #endregion

    }
}