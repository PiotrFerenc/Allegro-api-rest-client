using AllegroApi.Query.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class OfferEventsQueryValidator : AbstractValidator<OfferEventsQuery>
    {
        public OfferEventsQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();

            RuleFor(x => x).Must(HasOneFieldNotEmpty).WithMessage("Jedno z pól musi być wypełnione.");
        }

        private bool HasOneFieldNotEmpty(OfferEventsQuery arg)
        {
            var result = !string.IsNullOrEmpty(arg.From) || arg.Limit > 0 || arg.Type != OfferEventsQuery.OfferEventType.None;
            return result;
        }
    }
}