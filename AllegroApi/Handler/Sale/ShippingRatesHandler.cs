using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class ShippingRatesHandler: IRequestHandler<GetSellerShippingRatesQuery, ShippingRates>
    {
        private readonly ISaleService _sellerService;

        public ShippingRatesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<ShippingRates> Handle(GetSellerShippingRatesQuery request, CancellationToken cancellationToken)
        {

            await ValidatorHelper.TryValidate<SellerShippingRatesQueryValidator, GetSellerShippingRatesQuery>(request);

            var result = await _sellerService.GetSellerShippingAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}