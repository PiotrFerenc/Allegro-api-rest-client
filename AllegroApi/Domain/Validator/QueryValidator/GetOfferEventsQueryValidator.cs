using AllegroApi.Query.Offer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class GetOfferEventsQueryValidator : AbstractValidator<GetOfferEventsQuery>
    {
        public GetOfferEventsQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();

            RuleFor(x => x).Must(HasOneFieldNotEmpty).WithMessage("Jedno z pól musi być wypełnione.");
        }

        private bool HasOneFieldNotEmpty(GetOfferEventsQuery arg)
        {
            var result = !string.IsNullOrEmpty(arg.From) || arg.Limit > 0 || arg.Type != GetOfferEventsQuery.OfferEventType.NONE;
            return result;
        }
    }
}