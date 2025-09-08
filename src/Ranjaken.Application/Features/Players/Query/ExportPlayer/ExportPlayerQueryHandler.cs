using MediatR;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Ranjaken.Application.Features.Players.Query.ExportPlayer
{
    public class ExportPlayerQueryHandler(IExcelService _data, IGenericRepositoryAsync<Player> _repo) : IRequestHandler<ExportExcelQuery, byte[]>
    {
        public async Task<byte[]> Handle(ExportExcelQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<Player, object>>> includes = [p => p.Team];
            Expression<Func<Player, bool>> filter = player => true;
            filter = player => (
                string.IsNullOrEmpty(request.TeamName) ||
                (
                    player.Team.Name != null && player.FirstName.Contains(request.TeamName)
                )
           );
            
            (IEnumerable<Player> Data, long Total, int AllPage) = await _repo.GetAllAsync(filter, includes, null, null);
                       
            return _data.ExportPlayerExcel(Data);
        }
    }
}