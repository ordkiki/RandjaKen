using MediatR;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerQuery : IRequest<GetAllPlayerResponse>
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int? Limit { get; set; } = 10;
        public string? TeamName { get; set; } = string.Empty;
    }
}