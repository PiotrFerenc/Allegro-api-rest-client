using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroOffer.Event;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class OfferEventsHandler : IRequestHandler<GetOfferEventsQuery, OfferEvents>
    {
        private readonly IOfferService _offerService;

        public OfferEventsHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }


        public async Task<OfferEvents> Handle(GetOfferEventsQuery request, CancellationToken cancellationToken)
        {
            
            await ValidatorHelper.TryValidate<OfferEventsQueryValidator, GetOfferEventsQuery>(request);

            var result = await _offerService.GetOfferEventsAsync(request.Authorization, request.From, request.Limit, request.Type);

            return result;
        }
    }
}