using Ranjaken.Application.Dtos;

namespace Ranjaken.Application.Features.Teams.Query.GetAllTeam
{
    public class GetAllTeamResponse
    {
        public IEnumerable<TeamDto>? Data { get; set; }
        public long? Total { get; set; } = 0;
        public int? TotalPage { get; set; } = 1;
    }
}
