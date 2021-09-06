using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Service.AllegroOffer;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class OfferByIdHandler : IRequestHandler<OfferByIdQuery, Offer>
    {
        private readonly IOfferService _offerService;

        public OfferByIdHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<Offer> Handle(OfferByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new OfferByIdQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _offerService.GetOfferByIdAsync(request.Authorization, request.OfferId);

            return result;
        }
    }
}