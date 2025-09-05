using Ranjaken.Application.Dtos.PlayerDto;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerResponse
    {
        public IEnumerable<PlayerDto>? Data { get; set; }
        public long? Total { get; set; }
        public int TotalPage { get; set; } = 1;
    }
}