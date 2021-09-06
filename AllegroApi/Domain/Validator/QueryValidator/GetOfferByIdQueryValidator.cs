using AllegroApi.Query.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class OfferByIdQueryValidator : AbstractValidator<OfferByIdQuery>
    {
        public OfferByIdQueryValidator()
        {
            RuleFor(x => x.OfferId).NotEmpty();
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}