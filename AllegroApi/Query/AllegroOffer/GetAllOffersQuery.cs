using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    public class GetAllOffersQuery : AuthorizationToken, IRequest<List<Offer>>
    {
 
        public PublicationStatus PublicationStatus { get; set; }
    }
}