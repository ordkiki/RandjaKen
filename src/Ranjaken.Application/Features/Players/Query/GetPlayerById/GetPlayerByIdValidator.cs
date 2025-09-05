using FluentValidation;

namespace Ranjaken.Application.Features.Players.Query.GetPlayerById
{
    public class GetPlayerByIdValidator : AbstractValidator<GetPlayerByIdQuery>
    {
        public GetPlayerByIdValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Player Id is required");
        }
    }
}