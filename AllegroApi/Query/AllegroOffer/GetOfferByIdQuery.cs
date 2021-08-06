using AllegroApi.Domain.AllegroOffer;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    public class GetOfferByIdQuery : IRequest<Offer>
    {
        public string OfferId { get; init; }
        public string Authorization { get; init; }
    } 
}