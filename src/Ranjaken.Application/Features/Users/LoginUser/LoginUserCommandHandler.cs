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
            User user = await _repo.GetByEmailAsync(request.EmailAdress, null) ?? throw new ExistingEntityException("you have not an access to connect as admin", 400, false);

            if (user.Password != request.Password) throw new Exception("Invalid credentials");
            return new UserDto
            {
                UserEmail = user.EmailAdress,
                Password = user.Password
            };
        }
    }
}