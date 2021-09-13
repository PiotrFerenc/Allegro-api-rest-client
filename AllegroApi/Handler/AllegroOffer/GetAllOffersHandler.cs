using System;
using System.Collections.Generic;
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
    public class AllOffersHandler : IRequestHandler<GetAllOffersQuery, List<Offer>>
    {
        private readonly IOfferService _offerService;

        public AllOffersHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<List<Offer>> Handle(GetAllOffersQuery request, CancellationToken cancellationToken)
        {
            await ValidatorHelper.TryValidate<AllOffersQueryValidator, GetAllOffersQuery>(request);

            var result = await _offerService.GetOffersAsync(request.Authorization, request.PublicationStatus);

            return result;
        }
    }
}