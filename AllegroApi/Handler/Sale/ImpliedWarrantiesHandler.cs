using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroImpliedWarranties;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class ImpliedWarrantiesHandler: IRequestHandler<GetImpliedWarrantiesQuery, AllegroImpliedWarranties>
    {
        private readonly ISaleService _sellerService;

        public ImpliedWarrantiesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<AllegroImpliedWarranties> Handle(GetImpliedWarrantiesQuery request, CancellationToken cancellationToken)
        {
            var validator = new ImpliedWarrantiesQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _sellerService.GetImpliedWarrantiesAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}