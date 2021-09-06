using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.AllegroWarranties;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class WarrantiesHandler: IRequestHandler<WarrantiesQuery, Warranties>
    {
        private readonly ISaleService _sellerService;

        public WarrantiesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<Warranties> Handle(WarrantiesQuery request, CancellationToken cancellationToken)
        {
            var validator = new WarrantiesQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _sellerService.GetWarrantiesAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}