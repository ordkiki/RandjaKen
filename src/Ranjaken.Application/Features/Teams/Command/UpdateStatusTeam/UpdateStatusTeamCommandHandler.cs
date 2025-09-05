using MediatR;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Features.Teams.Command.UpdtateTeam;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;


namespace Ranjaken.Application.Features.Teams.Command.UpdateStatusTeam
{
  
namespace Ranjaken.Application.Features.Teams.Command.UpdtateTeam
    {
        public class UpdateStatusTeamCommandHandler(IGenericRepositoryAsync<Team> _repo) : IRequestHandler<UpdateStatusTeamCommand, TeamDto>
        {
            public async Task<TeamDto> Handle(UpdateStatusTeamCommand request, CancellationToken cancellationToken)
            {
                Team team = await _repo.GetByAsync(request.Id, null);
                team.Status = InsriptionStatus.APPROVED;
                Team updatedTeam = await _repo.UpdateAsync(request?.Id, team);
                await _repo.SaveChangeAsync();
                return updatedTeam.ToDto();
            }
        }
    }
}