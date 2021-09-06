using AllegroApi.Query;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Query.Sale;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class ImpliedWarrantiesQueryValidator: AbstractValidator<ImpliedWarrantiesQuery>
    {
        public ImpliedWarrantiesQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
            RuleFor(x => x.SellerId).NotEmpty();
        }
    }
}