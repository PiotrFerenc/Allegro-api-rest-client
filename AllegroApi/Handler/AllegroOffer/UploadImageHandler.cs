using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class UploadImageHandler : IRequestHandler<UploadImageCommand, string>
    {
        private readonly IOfferService _offerService;

        public UploadImageHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var result = await _offerService.UploadImage(request.Authorization, request.File);

            return result.location;
        }
    }
}