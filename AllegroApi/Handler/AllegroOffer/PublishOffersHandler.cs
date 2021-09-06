﻿using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Domain.AllegroOffer.Publication;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class PublishOffersHandler : IRequestHandler<PublishOffersCommand, CommandTask>
    {
        private readonly IOfferService _offerService;

        public PublishOffersHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }


        public async Task<CommandTask> Handle(PublishOffersCommand request, CancellationToken cancellationToken)
        {
            var result = await _offerService.PublishOffers(request.Authorization, new PublishOffer(request.Offers));

            return result;
        }
    }
}