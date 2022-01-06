using System;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.AllegroDeliveryMethods;
using AllegroApi.Domain.AllegroImpliedWarranties;
using AllegroApi.Domain.AllegroReturnPolicies;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.AllegroWarranties;
using AllegroApi.Domain.Pos;
using AllegroApi.Extensions;
using AllegroApi.Repository;
using AllegroApi.Service.Interfaces;
using RestSharp;

namespace AllegroApi.Service
{
    public class SaleService : ISaleService
    {
        private readonly IApiRepository _apiRepository;

        public SaleService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<ListOfDeliveryMethods> GetDeliveryMethodsAsync(string authorization)
        {
            var result = await _apiRepository.SendQuery<ListOfDeliveryMethods>(new RequestQuery()
            {
                Uri = new Uri("https://api.allegro.pl/sale/delivery-methods"),
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }

        public async Task<ShippingRates> GetSellerShippingAsync(string authorization, string sellerId)
        {
            var uri = new Uri("https://api.allegro.pl/sale/shipping-rates").AddParameter("seller.id", sellerId);

            var result = await _apiRepository.SendQuery<ShippingRates>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }

        public async Task<AllegroImpliedWarranties> GetImpliedWarrantiesAsync(string authorization, string sellerId)
        {
            var uri = new Uri("https://api.allegro.pl/after-sales-service-conditions/implied-warranties").AddParameter("seller.id", sellerId);

            var result = await _apiRepository.SendQuery<AllegroImpliedWarranties>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }

        public async Task<ReturnPolicies> GetReturnPoliciesAsync(string authorization, string sellerId)
        {
            var uri = new Uri("https://api.allegro.pl/after-sales-service-conditions/return-policies").AddParameter("seller.id", sellerId);

            var result = await _apiRepository.SendQuery<ReturnPolicies>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }

        public async Task<Warranties> GetWarrantiesAsync(string authorization, string sellerId)
        {
            var uri = new Uri("https://api.allegro.pl/after-sales-service-conditions/warranties").AddParameter("seller.id", sellerId);

            var result = await _apiRepository.SendQuery<Warranties>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }

        public async Task<Pos> GetPosListAsync(string authorization, string sellerId)
        {
            var result = await _apiRepository.SendQuery<Pos>(new RequestQuery()
            {
                Uri = new Uri("https://api.allegro.pl/points-of-service").AddParameter("seller.id", sellerId),
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }
    }
}