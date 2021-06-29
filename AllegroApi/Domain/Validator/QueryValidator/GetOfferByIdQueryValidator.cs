using AllegroApi.Query.Offer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class GetOfferByIdQueryValidator : AbstractValidator<GetOfferByIdQuery>
    {
        public GetOfferByIdQueryValidator()
        {
            RuleFor(x => x.OfferId).NotEmpty();
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}