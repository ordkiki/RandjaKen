using FluentValidation;
using Ranjaken.Application.Features.Users.Command.UpdatePlayer;
using static System.Net.Mime.MediaTypeNames;

namespace Ranjaken.Application.Features.Players.Command.UpdatePlayer
{
    public class UpdatePlayerValidator : AbstractValidator<UpdatePlayercommand>
    {
        private const int MinAge = 15; 
        private const int MaxAge = 120;
        private readonly string[] allowedContentTypes = ["image/jpeg", "image/png", "image/jpg", "image/webp", "image/gif", "image/jfif"];
        private const long maxSizeInBytes = 5 * 1024 * 1024;
        public UpdatePlayerValidator()
        {
            RuleFor(x => x.FirstName)
                   .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.Pseudo)
                .MaximumLength(50).WithMessage("Pseudo  must not exceed 50 characters.");
            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate is required.");
            RuleFor(x => x.BirthDate)
           .LessThanOrEqualTo(DateTime.Today)
           .WithMessage("La date de naissance ne peut pas être dans le futur.");

            // Âge minimum (par ex. 15 ans)
            RuleFor(x => x.BirthDate)
                .LessThanOrEqualTo(DateTime.Today.AddYears(-MinAge))
                .WithMessage($"L'utilisateur doit avoir au moins {MinAge} ans.");

            // Âge maximum (par ex. 120 ans)
            RuleFor(x => x.BirthDate)
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-MaxAge))
                .WithMessage($"La date de naissance est invalide (âge > {MaxAge} ans).");


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