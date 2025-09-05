using MediatR;

namespace Ranjaken.Application.Features.Users.Command.DeletePlayer
{
    public record DeletePlayerCommand(Guid? Id) : IRequest<bool>;
}