using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Domain.Entities;

namespace Ranjaken.Application.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerDto ToDto(this Player user)
        {
            PlayerDto PlayerDto = new();
            PlayerDto.Id = user.Id;
            PlayerDto.Pseudo = user.Pseudo;
            PlayerDto.BirthDate = user.BirthDate;
            PlayerDto.Idole = user.Idole;
            PlayerDto.Size = user.Size;
            PlayerDto.Avatar = user.Avatar;
            PlayerDto.Position = user.Position.ToString();
            PlayerDto.TeamName = user.Team?.Name;
            PlayerDto.TeamId = user.TeamId;
            return PlayerDto;
        }

        public static IEnumerable<PlayerDto> ToDtoList(this IEnumerable<Player> players)
        {
                return players.Select(player => new PlayerDto
                {
                    Id = player.Id,
                    Pseudo = player.Pseudo,
                    Idole = player.Idole,
                    BirthDate = player.BirthDate,
                    Avatar = player.Avatar,
                    Size = player.Size,
                    Position = player.Position.ToString(),
                    TeamName = player.Team?.Name,
                    TeamId = player.Team.Id  
                });
        }
    }
}
