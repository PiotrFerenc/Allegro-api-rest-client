using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.Command;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class UpdateOfferHandler : AsyncRequestHandler<UpdateOfferCommand>
    {
        private readonly IOfferService _offerService;

        public UpdateOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        protected override async Task Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            await ValidatorHelper.TryValidate<UpdateOfferCommandValidator, UpdateOfferCommand>(request);
            await _offerService.UpdateOffer(request.Authorization, request.Offer);
        }
    }
}