using FluentValidation;

namespace Ranjaken.Application.Features.Teams.Query.GetBy
{
    public class GetTeamByIdVallidator : AbstractValidator<GetTeamByIdQuery>
    {
        public GetTeamByIdVallidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User Id is required.")
                .NotEqual(Guid.Empty).WithMessage("User Id must be a valid non-empty GUID.");
        }
    }
}