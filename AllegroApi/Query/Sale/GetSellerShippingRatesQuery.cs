using AllegroApi.Domain.AllegroShippingRates;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class SellerShippingRatesQuery : AuthorizationToken, IRequest<ShippingRates>
    {
        public string SellerId { get; set; }
    }
}