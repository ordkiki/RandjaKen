using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Features.Users.Command.CreatePlayer;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Ranjaken.Application.Features.Users.Command.CreateManyPlayers
{
    public class CreateManyPlayersCommandHandler(IGenericRepositoryAsync<Player> _repo, IGenericRepositoryAsync<Team> _repoTeam, IFileService _file) : IRequestHandler<CreateManyPlayersCommand, List<PlayerDto>>
    {

        public async Task<List<PlayerDto>> Handle(CreateManyPlayersCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Team, Team>>? projection =
               team => new Team
               {
                   Id = team.Id,
                   Name = team.Name,
               };
            Team team = await _repoTeam.GetByAsync(request.TeamId, null, projection) ?? throw new ApiException("No team found with this Id", 400, false);

            List<Player> players = new();

            foreach (CreatePlayerCommand playerRequest in request?.Players)
            {
                Player player = new()
                {
                    FirstName = playerRequest.FirstName?.ToUpper(),
                    LastName = playerRequest.LastName,
                    Pseudo = playerRequest.Pseudo,
                    Age = playerRequest.Age,
                    Size = playerRequest.Size,
                    Position = playerRequest.Position,
                    TeamId = request.TeamId,
                    Avatar = await _file.UploadAsync(playerRequest.Avatar, "Player") ?? null
                };

                players.Add(player);
            }

            await _repo.CreateManyAsync(players);
            await _repo.SaveChangeAsync();
            return [.. players.ToDtoList()];
        }
    }
}