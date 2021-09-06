using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    public class AllOffersQuery : AuthorizationToken, IRequest<List<Offer>>
    {
 
        public PublicationStatus PublicationStatus { get; set; }
    }
}