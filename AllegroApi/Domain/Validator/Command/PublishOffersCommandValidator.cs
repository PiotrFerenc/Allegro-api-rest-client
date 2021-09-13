using System.Linq;
using AllegroApi.Command.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.Command
{
    public class PublishOffersCommandValidator : AbstractValidator<PublishOffersCommand>
    {
        public PublishOffersCommandValidator()
        {
            RuleFor(x => x.Offers).NotNull().Must(x => x.Any());
        }
    }
}