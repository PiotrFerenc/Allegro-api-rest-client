using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.SellerInformation;
using AllegroApi.Service.SellerInformation;
using MediatR;

namespace AllegroApi.Handler.SellerInformation
{
    
    public class ShippingRatesHandler: IRequestHandler<GetSellerShippingRatesQuery, ShippingRates>
    {
        private readonly ISellerService _sellerService;

        public ShippingRatesHandler(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<ShippingRates> Handle(GetSellerShippingRatesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSellerShippingRatesQueryValidator();
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