using MediatR;

namespace AllegroApi.Query.Offer
{
    public class GetOfferByIdQuery : IRequest<Domain.Offer.Offer>
    {
        public string OfferId { get; init; }
        public string Authorization { get; init; }
    } 
}