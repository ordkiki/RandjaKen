using FluentValidation;

namespace Ranjaken.Application.Features.Users.Command.CreatePlayer
{
    public class CreatePlayerValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.Pseudo)
                .NotEmpty().WithMessage("Pseudo  is required.")
                .MaximumLength(50).WithMessage("Pseudo  must not exceed 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required.")
                .InclusiveBetween(8, 35).WithMessage("Age must be between 5 and 50.");
            RuleFor(x => x.Size).NotEmpty().WithMessage("Age is required.")
                .InclusiveBetween(0, 350).WithMessage("Size must be between 0 and 350cm.");
            //RuleFor(x => x.EmailAdress).Matches(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
            //         @"([-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w])+(?:\.[-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w]+)*)" +
            //         @"@((\[(\d{1,3}\.){3}\d{1,3}\])|(([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}))$")
            //    .WithMessage("Email Format does not valid");
            //RuleFor(x => x.Telephone).NotEmpty().WithMessage("Telephone is required.")
            //    .Matches("^\\+?[0-9]+$").WithMessage("Only numeric")
            //    .MaximumLength(15).WithMessage("Telephone must not exceed 15 characters.");
        }
    }
}
