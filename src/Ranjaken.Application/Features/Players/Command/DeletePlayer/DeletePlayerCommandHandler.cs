using MediatR;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;

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