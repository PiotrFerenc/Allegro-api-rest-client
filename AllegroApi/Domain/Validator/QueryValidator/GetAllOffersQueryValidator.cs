using AllegroApi.Query.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class AllOffersQueryValidator: AbstractValidator<GetAllOffersQuery>
    {
        public AllOffersQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}