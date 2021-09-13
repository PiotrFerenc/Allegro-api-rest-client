using AllegroApi.Command.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.Command
{
    public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferCommandValidator()
        {
            RuleFor(x => x.Offer).NotNull();
        }
    }
}