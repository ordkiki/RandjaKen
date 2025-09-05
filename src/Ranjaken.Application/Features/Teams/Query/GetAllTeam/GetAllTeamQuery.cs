using MediatR;
using Ranjaken.Domain.Enums;

namespace Ranjaken.Application.Features.Teams.Query.GetAllTeam
{
    public class GetAllTeamQuery : IRequest<GetAllTeamResponse>
    {
        public string? Search { get; set; }
        public int? Page { get; set; } = 1;
        public int? Limit { get; set; } = 10;
        public string? Status { get; set; }
    }
}