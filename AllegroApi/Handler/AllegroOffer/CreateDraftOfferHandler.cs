using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class CreateDraftOfferHandler : IRequestHandler<CreateDraftOfferCommand, string>
    {
        private readonly IOfferService _offerService;

        public CreateDraftOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<string> Handle(CreateDraftOfferCommand request, CancellationToken cancellationToken)
        {
            var result = await _offerService.CreateOffer(request.Authorization, request.Offer);
            return result.Id;
        }
    }
}