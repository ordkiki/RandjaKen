using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Features.Teams.Command.CreateTeam;
using Ranjaken.Application.Features.Teams.Command.DeleteTeam;
using Ranjaken.Application.Features.Teams.Command.UpdateStatusTeam;
using Ranjaken.Application.Features.Teams.Command.UpdtateTeam;
using Ranjaken.Application.Features.Teams.Query.GetAllTeam;
using Ranjaken.Application.Features.Teams.Query.GetBy;
using Ranjaken.Domain.Exceptions;
using RanjaKen.Api.Model;

namespace RanjaKen.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TeamController(IMediator _mediator) : ControllerBase
    {
        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTeamCommand request)
        {
            TeamDto result = await _mediator.Send(request);
            if (request == null) throw new ApiException("Invalid request", 400, false);
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

        #region Update
        [HttpPut("{TeamId}")]
        public async Task<IActionResult> Update([FromRoute] Guid? TeamId, [FromForm] UpdateTeamCommand request)
        {
            TeamDto result = await _mediator.Send(new UpdateTeamCommand
            {
                Id = TeamId,
                Name = request.Name,
                Slogan = request.Slogan,
                Bio = request.Bio,
                EmailAdress = request.EmailAdress,
                PhoneNumber = request.PhoneNumber,
                Logo = request.Logo,
            });
            return Ok(new ApiResponse<TeamDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "updated with success",
                Meta = null
            });
        }
        #endregion

        #region Update
        [HttpPut("Status/{TeamId}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid TeamId, [FromForm] UpdateStatusTeamCommand request)
        {
            TeamDto result = await _mediator.Send(new UpdateStatusTeamCommand
            {
                Id = TeamId
            });
            return Ok(new ApiResponse<TeamDto>
            {
                Success = true,
                Code = StatusCodes.Status200OK,
                Data = result,
                Message = "update status with success",
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
        public async Task<IActionResult> GetMany([FromQuery] GetAllTeamQuery request)
        {
            GetAllTeamResponse? result = await _mediator.Send(request);
            return Ok(new ApiResponse<IEnumerable<TeamDto>>
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
