using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;

namespace Ranjaken.Application.Features.Users.Command.CreatePlayer
{
    public class CreatePlayerCommandHandler(IGenericRepositoryAsync<Player> _repo, IFileService _file) : IRequestHandler<CreatePlayerCommand, PlayerDto>
    {

        public async Task<PlayerDto> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            Player player = new()
            {
                FirstName = request?.FirstName?.ToUpper(),
                LastName = request?.LastName,
                Pseudo = request?.Pseudo,
                Age = request?.Age,
                Size = request?.Size,
                Position = request?.Position,
            };
            player.Avatar = await _file.UploadAsync(request?.Avatar, "Player");
            await _repo.CreateAsync(player);
            await _repo.SaveChangeAsync();
            return player.ToDto();
        }
    }
}