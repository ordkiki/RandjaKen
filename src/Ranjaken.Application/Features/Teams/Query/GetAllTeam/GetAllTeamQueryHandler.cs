using MediatR;
using Ranjaken.Application.Dtos;
using Ranjaken.Application.Features.Users.Query.GetAllPlayer;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Query.GetAllTeam
{
    public class GetAllTeamQueryHandler(IGenericRepositoryAsync<Team> _repo) : IRequestHandler<GetAllTeamQuery, GetAllTeamResponse>
    {
        public async Task<GetAllTeamResponse> Handle(GetAllTeamQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Team, bool>> filter = team => true;

            filter = team =>

               (
                    string.IsNullOrEmpty(request.Search) ||
                    (
                        team.Name.Contains(request.Search) ||
                        team.Slogan.Contains(request.Search)
                    )
               )    
               &&
               (
                    string.IsNullOrEmpty(request.Status) || (team.Status != null && team.Status.ToString().Contains(request.Status))
               )
            ;

            (IEnumerable<Team> Data, long Total, int AllPage) result = await _repo.GetAllAsync(filter ?? null, null, null, null);
            return new GetAllTeamResponse()
            {
                Data = [..result.Data.ToDtoList()],
                Total = result.Total,
                TotalPage = result.AllPage
            };
        }
    }
}
