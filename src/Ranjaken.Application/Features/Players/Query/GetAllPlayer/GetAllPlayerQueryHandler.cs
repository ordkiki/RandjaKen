using MediatR;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerQueryHandler(IGenericRepositoryAsync<Player> _repo) : IRequestHandler<GetAllPlayerQuery, GetAllPlayerResponse>
    {
        public int CalculateAge(DateOnly? birthDate)
        {
            if (!birthDate.HasValue) return 0;
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthDate.Value.Year;
            if (today < birthDate.Value.AddYears(age)) age--;
            return age;
        }
        public async Task<GetAllPlayerResponse> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<Player, object>>> includes = [p => p.Team];
            Expression<Func<Player, bool>> filter = player => true;

            filter = player => (
                    string.IsNullOrEmpty(request.Search) ||
                    (
                        player.FirstName.Contains(request.Search) ||
                        player.LastName.Contains(request.Search) ||
                        player.CreatedAt.ToString().Contains(request.Search)
                    )
                    &&
                    string.IsNullOrEmpty(request.TeamName) ||
                    (
                        player.Team.Name != null && player.FirstName.Contains(request.TeamName)
                    )
                    &&

                    (
                        !request.Age.HasValue || (
                        player.BirthDate.HasValue &&
                        
                        (DateTime.Today.Year - player.BirthDate.Value.Year -
                            ((DateTime.Today.Month < player.BirthDate.Value.Month ||
                             (DateTime.Today.Month == player.BirthDate.Value.Month &&
                              DateTime.Today.Day < player.BirthDate.Value.Day)) ? 1 : 0)
                        ) >= request.Age.Value
        )
                    )
            );

            (IEnumerable<Player> Data, long Total, int AllPage) = await _repo.GetAllAsync(filter, includes, null, null);
            return new GetAllPlayerResponse()
            {
                Data = [.. Data.ToDtoList()],
                Total = Total,
                TotalPage = AllPage
            };
        }
    }
}