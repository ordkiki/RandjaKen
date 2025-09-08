using MediatR;
using Ranjaken.Application.Dtos;

namespace Ranjaken.Application.Features.Teams.Command.UpdateStatusTeam
{
    public class UpdateStatusTeamCommand:IRequest<TeamDto>
    {
        public Guid Id { get; set; }
    }
}