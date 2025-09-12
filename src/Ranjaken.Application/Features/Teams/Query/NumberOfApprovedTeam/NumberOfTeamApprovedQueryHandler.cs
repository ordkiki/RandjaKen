using MediatR;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Enums;

namespace Ranjaken.Application.Features.Teams.Query.NewFolder
{
    public class NumberOfTeamApprovedQueryHandler(IGenericRepositoryAsync<Team> _repo) : IRequestHandler<NumbreOfTeamApprovedQuery, int>
    {
        public async Task<int> Handle(NumbreOfTeamApprovedQuery request, CancellationToken cancellationToken)
        {
            var (Data, Total, AllPage) = await _repo.GetAllAsync(t => t.Status == InsriptionStatus.APPROVED);
            return (int)Total;
        }
    }
}