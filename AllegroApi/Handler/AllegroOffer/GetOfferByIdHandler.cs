using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class OfferByIdHandler : IRequestHandler<GetOfferByIdQuery, Offer>
    {
        private readonly IOfferService _offerService;

        public OfferByIdHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<Offer> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
          await  ValidatorHelper.TryValidate<OfferByIdQueryValidator,GetOfferByIdQuery>(request);
          

            var result = await _offerService.GetOfferByIdAsync(request.Authorization, request.OfferId);

            return result;
        }
    }
}