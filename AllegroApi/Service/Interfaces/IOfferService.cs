using System.Collections.Generic;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.AllegroOffer.Event;
using AllegroApi.Domain.AllegroOffer.Publication;
using AllegroApi.Domain.AllegroOffer.Upload;
using AllegroApi.Domain.AllegroProduct;
using AllegroApi.Query.AllegroOffer;

namespace AllegroApi.Service.Interfaces
{
    public interface IOfferService
    {
        Task<Offer> GetOfferByIdAsync(string authorization, string offerId);
        Task<OfferEvents> GetOfferEventsAsync(string authorization,string from, int limit, GetOfferEventsQuery.OfferEventType type );
        Task<List<Offer>> GetOffersAsync(string authorization, PublicationStatus publicationStatus);
        Task<Offer> CreateOffer(string authorization,NewOffer newOffer);
        Task UpdateOffer(string authorization,Offer newOffer);
        Task<CommandTask> PublishOffers(string authorization,PublishOffer offers);
        Task<AllegroProduct> GetProducts(string requestAuthorization, string requestName);
        Task<UploadImageResult> UploadImage(string requestAuthorization, byte[] file);
    }
}