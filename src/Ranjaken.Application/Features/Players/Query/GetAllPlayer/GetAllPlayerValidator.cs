using FluentValidation;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerValidator : AbstractValidator<GetAllPlayerQuery>
    {
        public GetAllPlayerValidator()
        {
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("filter Age must be greater than 0");
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
            RuleFor(x => x.Limit)
                .GreaterThan(0).When(x => x.Limit.HasValue).WithMessage("Limit must be greater than 0 if specified.");
        }
    }
}