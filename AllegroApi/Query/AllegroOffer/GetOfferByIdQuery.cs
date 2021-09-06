using AllegroApi.Domain.AllegroOffer;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    public class OfferByIdQuery : AuthorizationToken, IRequest<Offer>
    {
        public string OfferId { get; init; } 
    } 
}