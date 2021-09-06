using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class ShippingRatesHandler: IRequestHandler<SellerShippingRatesQuery, ShippingRates>
    {
        private readonly ISaleService _sellerService;

        public ShippingRatesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<ShippingRates> Handle(SellerShippingRatesQuery request, CancellationToken cancellationToken)
        {
            var validator = new SellerShippingRatesQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _sellerService.GetSellerShippingAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}