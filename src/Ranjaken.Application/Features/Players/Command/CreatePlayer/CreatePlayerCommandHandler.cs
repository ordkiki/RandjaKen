using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Ranjaken.Application.Features.Users.Command.CreatePlayer
{
    public class CreatePlayerCommandHandler(IGenericRepositoryAsync<Player> _repo, IGenericRepositoryAsync<Team> _repoTeam, IFileService _file) : IRequestHandler<CreatePlayerCommand, PlayerDto>
    {

        public async Task<PlayerDto> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Team, Team>>? projection =
               team => new Team
               {
                   Id = team.Id,
                   Name = team.Name,
               };
            Team team = await _repoTeam.GetByAsync(request.TeamId, null, projection) ?? throw new ApiException("No team found with this Id", 400, false);

            Player player = new()
            {
                FirstName = request?.FirstName?.ToUpper(),
                LastName = request?.LastName,
                Pseudo = request?.Pseudo,
                Age = request?.Age,
                Size = request?.Size,
                Position = request?.Position,
                TeamId = request?.TeamId,
            };
            player.Avatar = await _file.UploadAsync(request?.Avatar, "Player");
            await _repo.CreateAsync(player);
            await _repo.SaveChangeAsync();
            return player.ToDto();
        }
    }
}