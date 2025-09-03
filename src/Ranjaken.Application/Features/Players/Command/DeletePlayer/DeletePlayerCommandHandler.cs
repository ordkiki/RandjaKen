using MediatR;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.DeletePlayer
{
    public class DeletePlayerCommandHandler(IGenericRepositoryAsync<Player> _repo) : IRequestHandler<DeletePlayerCommand, bool>
    {
        public async Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _repo.DeleteAsync(request.Id);
            await _repo.SaveChangeAsync();
            return isDeleted;
        }
    }
}