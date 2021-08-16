using System.Threading.Tasks;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.ImpliedWarranties;

namespace AllegroApi.Service.Sale
{
    public interface ISaleService
    {
        Task<Domain.AllegroDeliveryMethods.ListOfDeliveryMethods> GetDeliveryMethodsAsync(string authorization);
        Task<ShippingRates> GetSellerShippingAsync(string authorization, string sellerId);
        Task<Warranties> GetImpliedWarrantiesAsync(string authorization, string sellerId);
    }
}