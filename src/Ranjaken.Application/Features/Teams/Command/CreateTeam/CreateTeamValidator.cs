using FluentValidation;

namespace Ranjaken.Application.Features.Teams.Command.CreateTeam
{
    public class CreateTeamValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(150).WithMessage("Can not excced 150 character");
            RuleFor(x => x.EmailAdress).Matches(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                     @"([-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w])+(?:\.[-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w]+)*)" +
                     @"@((\[(\d{1,3}\.){3}\d{1,3}\])|(([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}))$")
                .WithMessage("Email Format does not valid");
            RuleFor(x => x.PhoneNumber).NotEmpty()
                .WithMessage("Telephone is required.")
                .Matches("^\\+?[0-9]+$").WithMessage("number not valid (eg :+261381300400, 0381300400)")
                .MinimumLength(10).WithMessage("Telephone must be exced 10 characters.")
                .MaximumLength(15).WithMessage("Telephone must be exced 10 characters.");
            //RuleFor(x => x.Status).IsInEnum().WithMessage("Status must be in enum, eg : PENDING, APPROVED");
            RuleFor(x => x.Slogan).MaximumLength(5000).WithMessage("\"Slogan can not exceed 5000 characters\"");
            RuleFor(x => x.Bio).MaximumLength(5000).WithMessage("Bio can not exceed 5000 characters");
        }
    }
}
