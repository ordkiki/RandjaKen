using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Command.DeleteTeam
{
    public class DeleteTeamValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User Id is required.")
                .NotEqual(Guid.Empty).WithMessage("User Id must be a valid non-empty GUID.");
        }
    }
}
