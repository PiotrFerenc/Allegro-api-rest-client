using System.Collections.Generic;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.AllegroOffer.Event;
using AllegroApi.Query.AllegroOffer;

namespace AllegroApi.Service.Interfaces
{
    public interface IOfferService
    {
        Task<Domain.AllegroOffer.Offer> GetOfferByIdAsync(string authorization, string offerId);
        Task<OfferEvents> GetOfferEventsAsync(string authorization,string from, int limit, OfferEventsQuery.OfferEventType type );
        Task<List<Domain.AllegroOffer.Offer>> GetOffersAsync(string authorization, PublicationStatus publicationStatus);
        Task<Offer> CreateOffer(string authorization,NewOffer newOffer);
        Task UpdateOffer(string authorization,Offer newOffer);
    }
}