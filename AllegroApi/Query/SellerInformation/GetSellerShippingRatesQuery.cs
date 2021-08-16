using AllegroApi.Domain.AllegroShippingRates;
using MediatR;

namespace AllegroApi.Query.SellerInformation
{
    public class GetSellerShippingRatesQuery : AuthorizationToken, IRequest<ShippingRates>
    {
        public string SellerId { get; set; }
    }
}