using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    public class GetAllOffersQuery : IRequest<List<Offer>>
    {
        public string Authorization { get; init; }
        public PublicationStatus PublicationStatus { get; set; }
    }
}