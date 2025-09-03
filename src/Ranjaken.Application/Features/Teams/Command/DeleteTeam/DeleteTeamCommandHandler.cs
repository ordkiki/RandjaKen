using MediatR;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Command.DeleteTeam
{
    public class DeleteTeamCommandHandler(IGenericRepositoryAsync<Team> _repo) : IRequestHandler<DeleteTeamCommand, bool>
    {
        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _repo.DeleteAsync(request.Id);
            await _repo.SaveChangeAsync();
            return isDeleted;
        }
    }
}
