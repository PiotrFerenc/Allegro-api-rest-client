using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.AllegroWarranties;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class WarrantiesHandler: IRequestHandler<GetWarrantiesQuery, Warranties>
    {
        private readonly ISaleService _sellerService;

        public WarrantiesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<Warranties> Handle(GetWarrantiesQuery request, CancellationToken cancellationToken)
        {
   
            await ValidatorHelper.TryValidate<WarrantiesQueryValidator, GetWarrantiesQuery>(request);

            var result = await _sellerService.GetWarrantiesAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}