using MediatR;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;

namespace Ranjaken.Application.Features.Teams.Command.UpdtateTeam
{
    public class UpdateTeamCommandHandler(IGenericRepositoryAsync<Team> _repo, IFileService _file) : IRequestHandler<UpdateTeamCommand, TeamDto>
    {
        public async Task<TeamDto> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            Team team = await _repo.GetByAsync(request.Id, null);
            team.Name = request?.Name ?? team.Name;
            team.Bio = request?.Bio ?? team.Bio;
            team.Slogan = request?.Slogan ?? team.Slogan;
            team.PhoneNumber = request?.PhoneNumber ?? team.PhoneNumber;
            team.EmailAdress = request?.EmailAdress ?? team.EmailAdress;
            team.Status = team.Status;
            team.Logo = await _file.UploadAsync(request?.Attachement, "Team_Logo");

            Team updatedTeam = await _repo.UpdateAsync(request?.Id, team);
            await _repo.SaveChangeAsync();

            return updatedTeam.ToDto();
        }
    }
}