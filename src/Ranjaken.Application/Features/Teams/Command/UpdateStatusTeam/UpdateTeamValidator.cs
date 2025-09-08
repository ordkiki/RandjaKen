using FluentValidation;

namespace Ranjaken.Application.Features.Teams.Command.UpdateStatusTeam
{
    public class UpdateTeamValidator : AbstractValidator<UpdateStatusTeamCommand>
    {
        public UpdateTeamValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Team Id is required");
        }
    }
}
