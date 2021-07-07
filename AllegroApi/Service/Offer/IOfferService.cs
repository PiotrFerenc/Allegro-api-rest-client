using System.Threading.Tasks;
using AllegroApi.Domain.Offer.Event;
using AllegroApi.Query.Offer;

namespace AllegroApi.Service.Offer
{
    public interface IOfferService
    {
        Task<Domain.Offer.Offer> GetOfferByIdAsync(string authorization, string offerId);
        Task<OfferEvents> GetOfferEventsAsync(string authorization,string from, int limit, GetOfferEventsQuery
        .OfferEventType type );
    }
}