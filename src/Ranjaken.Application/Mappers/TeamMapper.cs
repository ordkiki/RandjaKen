using Ranjaken.Application.Dtos;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Features.Teams.Query.GetBy;
using Ranjaken.Domain.Entities;

namespace Ranjaken.Application.Mappers
{
    public static class TeamMapper
    {
        public static TeamDto ToDto(this Team team)
        {
            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                PhoneNumber = team.PhoneNumber,
                EmailAdress = team.EmailAdress,
                SocialMedia = team.SocialMedia ?? null,
                Logo = team.Logo,
                Slogan = team.Slogan,
                Bio = team.Bio,
                Status = team.Status.ToString(),
            };
        }

        public static IEnumerable<TeamDto> ToDtoList(this IEnumerable<Team> teams)
        {
            return teams.Select(team => new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Slogan = team.Slogan,
                Bio = team.Bio,
                Logo = team.Logo,
                EmailAdress = team.EmailAdress,
                SocialMedia = team.SocialMedia ?? null,
                PhoneNumber = team?.PhoneNumber,
                Status = team?.Status.ToString()
            });
        }

        public static GetTeamByIdResponse ToDtoWithPlayer(this Team team)
        {
            return new GetTeamByIdResponse
            {
                Name = team.Name,
                PhoneNumber = team.PhoneNumber,
                EmailAdress = team.EmailAdress,
                Logo = team.Logo,
                Slogan = team.Slogan,
                Bio = team.Bio,
                Status = team.Status.ToString(),
                Players = team.Players?.Select(b => new PlayerWithTeamDto{
                    Id = b.Id,
                    Age = b.Age,
                    Position = b.Position.ToString(),
                    Pseudo = b.Pseudo,
                    Size = b.Size
                }).ToList() ?? [],
            };
        }
    }
}
