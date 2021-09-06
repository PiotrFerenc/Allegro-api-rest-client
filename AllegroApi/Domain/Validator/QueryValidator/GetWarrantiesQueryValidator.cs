using AllegroApi.Query.Sale;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class WarrantiesQueryValidator: AbstractValidator<WarrantiesQuery>
    {
        public WarrantiesQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
            RuleFor(x => x.SellerId).NotEmpty();
        }
    }
}