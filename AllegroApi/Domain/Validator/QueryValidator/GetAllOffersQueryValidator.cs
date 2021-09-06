using AllegroApi.Query.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class AllOffersQueryValidator: AbstractValidator<AllOffersQuery>
    {
        public AllOffersQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}