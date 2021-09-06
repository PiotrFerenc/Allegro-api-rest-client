using AllegroApi.Query;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Query.Sale;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class ReturnPoliciesQueryValidator: AbstractValidator<ReturnPoliciesQuery>
    {
        public ReturnPoliciesQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
            RuleFor(x => x.SellerId).NotEmpty();
        }
    }
}