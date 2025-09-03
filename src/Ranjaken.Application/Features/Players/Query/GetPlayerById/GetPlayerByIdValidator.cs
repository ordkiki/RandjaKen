using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
