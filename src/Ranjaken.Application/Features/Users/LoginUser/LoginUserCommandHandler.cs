using MediatR;
using Ranjaken.Application.Dtos;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Services;

namespace Ranjaken.Application.Features.Users.LoginUser
{
    public class LoginUserCommandHandler(IGenericEmailService<User> _repo) : IRequestHandler<LoginUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _repo.GetByEmailAsync(request.EmailAdress, null)
                ?? throw new ApiException("you have not an access to the page admin", 400, false);

            if (user.Password != request.Password) throw new ApiException("Invalid credentials", 400 ,false);
            return new UserDto
            {
                UserEmail = user.EmailAdress,
                Password = user.Password
            };
        }
    }
}