using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;

namespace Ranjaken.Application.Features.Users.Command.UpdatePlayer
{
    public class UpdatePlayerCommandHandler(IGenericRepositoryAsync<Player> _repo, IFileService _file) : IRequestHandler<UpdatePlayercommand, PlayerDto>
    {
        public async Task<PlayerDto> Handle(UpdatePlayercommand request, CancellationToken cancellationToken)
        {
            Player player = await _repo.GetByAsync(request.Id, null);
            player.LastName = request?.LastName ?? player.LastName;
            player.FirstName = request?.FirstName ?? player.FirstName;
            player.Pseudo = request?.Pseudo ?? player.Pseudo;   
            player.Age = request?.Age ?? player.Age;
            player.Size = request?.Size ?? player.Size;
            player.Avatar = request?.Avatar != null ? await _file.UploadAsync(request?.Avatar, "Avatar") : player.Avatar;
            player.Position = request?.Position ?? player.Position;
            Player updatedPlayer = await _repo.UpdateAsync(request?.Id, player);
            await _repo.SaveChangeAsync();

            return updatedPlayer.ToDto();
        }
    }
}
