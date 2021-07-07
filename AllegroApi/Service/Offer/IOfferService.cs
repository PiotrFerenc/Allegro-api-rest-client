using System.Threading.Tasks;

namespace AllegroApi.Service.Offer
{
    public interface IOfferService
    {
        Task<Domain.Offer.Offer> GetOfferById(string authorization, string offerId);
    }
}