using AllegroApi.Query;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Query.Sale;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class DeliveryMethodsQueryValidator: AbstractValidator<GetDeliveryMethodsQuery>
    {
        public DeliveryMethodsQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}