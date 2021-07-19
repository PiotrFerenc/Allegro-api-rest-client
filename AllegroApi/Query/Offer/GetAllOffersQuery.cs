using System.Collections.Generic;
using AllegroApi.Service.Offer;
using MediatR;

namespace AllegroApi.Query.Offer
{
    public class GetAllOffersQuery : IRequest<List<Domain.Offer.Offer>>
    {
        public string Authorization { get; init; }
        public PublicationStatus PublicationStatus { get; set; }
    }
}