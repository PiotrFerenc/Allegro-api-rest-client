using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.AllegroDeliveryMethods;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Extensions;
using AllegroApi.Repository;

namespace AllegroApi.Service.SellerInformation
{
    public class SellerService : ISellerService
    {
        private readonly IApiRepository _apiRepository;

        public SellerService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<ListOfDeliveryMethods> GetDeliveryMethodsAsync(string authorization)
        {
            var result = await _apiRepository.SendQuery<ListOfDeliveryMethods>(new RequestQuery()
            {
                Uri = new Uri("https://api.allegro.pl/sale/delivery-methods"),
                Authorization = authorization,
                Method = "GET"
            });

            if (result.IsFailed)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Message)));
            }

            return result.Value;
        }

        public async Task<ShippingRates> GetSellerShippingAsync(string authorization, string sellerId)
        {
            var uri = new Uri("https://api.allegro.pl/sale/shipping-rates").AddParameter("seller.id", sellerId);
                
            var result = await _apiRepository.SendQuery<ShippingRates>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = "GET" 
            });

            if (result.IsFailed)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Message)));
            }

            return result.Value;
        }
    }

    public interface ISellerService
    {
        Task<Domain.AllegroDeliveryMethods.ListOfDeliveryMethods> GetDeliveryMethodsAsync(string authorization);
        Task<ShippingRates> GetSellerShippingAsync(string authorization, string sellerId);
    }
}