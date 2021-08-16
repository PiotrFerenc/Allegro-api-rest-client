using AllegroApi.Query;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Query.Sale;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class GetDeliveryMethodsQueryValidator: AbstractValidator<GetDeliveryMethodsQuery>
    {
        public GetDeliveryMethodsQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}