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
    public class CreateTeamCommandHandler(IGenericRepositoryAsync<Team> _repo,IGenericEmailService<Team> _query ,IFileService _file) : IRequestHandler<CreateTeamCommand, TeamDto>
    {
        public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team? ExistingTeam = await _query.GetByEmailAsync(request.EmailAdress, null) ;
            if (ExistingTeam != null) throw new ApiException("A team with this email already exists", 400, false);
            Team team = new()
            {
                Name = request?.Name,
                Bio = request?.Bio,
                Slogan = request?.Slogan,
                PhoneNumber = request?.PhoneNumber,
                EmailAdress = request?.EmailAdress,
                Status = InsriptionStatus.PENDING,
                Logo = await _file.UploadAsync(request?.Logo, "Logo") ?? null
            };
            await _repo.CreateAsync(team);
            await _repo.SaveChangeAsync();
            return team.ToDto();
        }
    }
}