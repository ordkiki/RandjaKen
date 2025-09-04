using FluentValidation;

namespace Ranjaken.Application.Features.Users.LoginUser
{
    public class LoginValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.EmailAdress)
                .NotEmpty().WithMessage("Email address is required.");
                RuleFor(x => x.EmailAdress).Matches(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                     @"([-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w])+(?:\.[-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w]+)*)" +
                     @"@((\[(\d{1,3}\.){3}\d{1,3}\])|(([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}))$");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
