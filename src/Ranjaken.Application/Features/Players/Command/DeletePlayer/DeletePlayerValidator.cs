using FluentValidation;

namespace Ranjaken.Application.Features.Users.Command.DeletePlayer
{
    public class DeletePlayerValidator : AbstractValidator<DeletePlayerCommand>
    {
        public DeletePlayerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User Id is required.")
                .NotEqual(Guid.Empty).WithMessage("User Id must be a valid non-empty GUID.");
        }
    }
}