﻿using System.Threading.Tasks;
using AllegroApi.Domain.AllegroImpliedWarranties;
using AllegroApi.Domain.AllegroReturnPolicies;
using AllegroApi.Domain.AllegroShippingRates;

namespace AllegroApi.Service.Sale
{
    public interface ISaleService
    {
        Task<Domain.AllegroDeliveryMethods.ListOfDeliveryMethods> GetDeliveryMethodsAsync(string authorization);
        Task<ShippingRates> GetSellerShippingAsync(string authorization, string sellerId);
        Task<AllegroImpliedWarranties> GetImpliedWarrantiesAsync(string authorization, string sellerId);
        Task<ReturnPolicies> GetReturnPoliciesAsync(string authorization, string sellerId);
    }
}