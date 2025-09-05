using MediatR;
using Ranjaken.Application.Dtos;
using Ranjaken.Domain.Enums;

namespace Ranjaken.Application.Features.Teams.Command.UpdateStatusTeam
{
    public class UpdateStatusTeamCommand:IRequest<TeamDto>
    {
        public Guid Id { get; set; }
        public InsriptionStatus Status { get; set; }
    }
}