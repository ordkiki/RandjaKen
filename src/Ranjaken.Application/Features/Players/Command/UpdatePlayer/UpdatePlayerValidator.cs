using FluentValidation;
using Ranjaken.Application.Features.Users.Command.UpdatePlayer;

namespace Ranjaken.Application.Features.Players.Command.UpdatePlayer
{
    public class UpdatePlayerValidator : AbstractValidator<UpdatePlayercommand>
    {
        private readonly string[] allowedContentTypes = ["image/jpeg", "image/png", "image/jpg", "image/gif", "image/jfif"];
        private const long maxSizeInBytes = 5 * 1024 * 1024;
        public UpdatePlayerValidator()
        {
            RuleFor(x => x.FirstName)
                   .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.Pseudo)
                .MaximumLength(50).WithMessage("Pseudo  must not exceed 50 characters.");
            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.Age)
                .InclusiveBetween(8, 35).WithMessage("Age must be between 5 and 50.");
            RuleFor(x => x.Size)
                .InclusiveBetween(0, 350).WithMessage("Size must be between 0 and 350cm.");

            When(x => x.Avatar != null, () => RuleFor(x => x.Avatar)
                .Must(file => file != null && file.Length > 0).WithMessage("Le fichier ne peut pas être vide.")
                .Must(file => file != null && allowedContentTypes.Contains(file.ContentType)).WithMessage("Le type de fichier n'est pas pris en charge (jpg, jpeg, png, gif).")
                .Must(file => file != null && file.Length <= maxSizeInBytes).WithMessage("Le fichier ne doit pas dépasser 5 Mo.")
            );
        }
    }
}