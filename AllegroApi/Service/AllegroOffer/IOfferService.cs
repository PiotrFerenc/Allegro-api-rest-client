using System.Collections.Generic;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroOffer.Event;
using AllegroApi.Query.AllegroOffer;

namespace AllegroApi.Service.AllegroOffer
{
    public interface IOfferService
    {
        Task<Domain.AllegroOffer.Offer> GetOfferByIdAsync(string authorization, string offerId);
        Task<OfferEvents> GetOfferEventsAsync(string authorization,string from, int limit, GetOfferEventsQuery.OfferEventType type );
        Task<List<Domain.AllegroOffer.Offer>> GetOffersAsync(string authorization, PublicationStatus publicationStatus);
    }
}