using MediatR;
using Ranjaken.Application.Dtos;

namespace Ranjaken.Application.Features.Users.LoginUser
{
    public record LoginUserCommand: IRequest<UserDto>
    {
        public string? EmailAdress { get; set; }
        public string? Password { get; set; }
    }
}