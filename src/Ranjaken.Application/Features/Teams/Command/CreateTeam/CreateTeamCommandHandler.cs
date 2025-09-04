using MediatR;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;

namespace Ranjaken.Application.Features.Teams.Command.CreateTeam
{
    public class CreateTeamCommandHandler(IGenericRepositoryAsync<Team> _repo, IFileService _file) : IRequestHandler<CreateTeamCommand, TeamDto>
    {
        public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team? ExistingTeam = await _repo.GetByEmailAsync(request.EmailAdress, null) ;
            if (ExistingTeam != null) throw new ApiException("A team with this email already exists", 400, false);
            Team team = new()
            {
                Name = request?.Name,
                PhoneNumber = request?.PhoneNumber,
                Bio = request?.Bio,
                Slogan = request?.Slogan,
                EmailAdress = request?.EmailAdress,
                
            };
            team.Status = InsriptionStatus.PENDING;
            team.Logo = await _file.UploadAsync(request?.Attachement, "Logo") ?? null;
            await _repo.CreateAsync(team);
            await _repo.SaveChangeAsync();
            return team.ToDto();
        }
    }
}