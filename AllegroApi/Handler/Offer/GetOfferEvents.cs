﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.Offer.Event;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Offer;
using AllegroApi.Service.Offer;
using MediatR;

namespace AllegroApi.Handler.Offer
{
    public class GetOfferEventsHandler : IRequestHandler<GetOfferEventsQuery, OfferEvents>
    {
        private readonly IOfferService _offerService;

        public GetOfferEventsHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }


        public async Task<OfferEvents> Handle(GetOfferEventsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOfferEventsQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _offerService.GetOfferEventsAsync(request.Authorization, request.From, request.Limit, request.Type);

            return result;
        }
    }
}