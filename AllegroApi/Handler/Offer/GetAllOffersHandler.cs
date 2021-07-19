using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Offer;
using AllegroApi.Service.Offer;
using MediatR;

namespace AllegroApi.Handler.Offer
{
    public class GetAllOffersHandler : IRequestHandler<GetAllOffersQuery, List<Domain.Offer.Offer>>
    {
        private readonly IOfferService _offerService;

        public GetAllOffersHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<List<Domain.Offer.Offer>> Handle(GetAllOffersQuery request, CancellationToken
            cancellationToken)
        {
            var validator = new GetAllOffersQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _offerService.GetOffersAsync(request.Authorization,request.PublicationStatus);

            return result;
        }
    }
}