using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Features.Players.Query.GetPlayerById;
using Ranjaken.Application.Features.Teams.Command.CreateTeam;
using Ranjaken.Application.Features.Teams.Command.DeleteTeam;
using Ranjaken.Application.Features.Teams.Query.GetAllTeam;
using Ranjaken.Application.Features.Teams.Query.GetBy;
using Ranjaken.Application.Features.Users.Command.CreatePlayer;
using Ranjaken.Application.Features.Users.Command.DeletePlayer;
using Ranjaken.Application.Features.Users.Query.GetAllPlayer;
using RanjaKen.Api.Model;

namespace RanjaKen.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class TeamController(IMediator _mediator) : ControllerBase
    {
        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTeamRequest request)
        {
            TeamDto result = await _mediator.Send(new CreateTeamCommand
            {
                Name = request.Name,
                Slogan = request.Slogan,
                Bio = request.Bio,
                EmailAdress = request.EmailAdress,
                PhoneNumber = request.PhoneNumber,
                Attachement = request.Logo
            });
            return Ok(new ApiResponse<TeamDto>
            {
                Success = true,
                Code = StatusCodes.Status201Created,
                Data = result,
                Message = "created with  success",
                Meta = null
            });
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid? TeamId)
        {
            await _mediator.Send(new DeleteTeamCommand(TeamId));
            return Ok(new ApiResponse<TeamDto>
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
        public async Task<IActionResult> GetMany([FromQuery] GetAllTeamQuery? request)
        {
            GetAllTeamResponse result = await _mediator.Send(new GetAllTeamQuery()
            {
                Search = request?.Search,
                Page = request.Page,
                Limit = request?.Limit
            });
            return Ok(new ApiResponse<List<TeamDto>>
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
            GetTeamByIdResponse result = await _mediator.Send(new GetTeamByIdQuery(Id));
            return Ok(new ApiResponse<GetTeamByIdResponse>
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
