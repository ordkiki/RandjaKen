using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Command.UpdateStatusTeam
{
    public class UpdateTeamValidator : AbstractValidator<UpdateStatusTeamCommand>
    {
        public UpdateTeamValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Team Id is required");
            RuleFor(t => t.Status).IsInEnum().WithMessage("Invalid status value");
        }
    }
}
