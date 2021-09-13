using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroImpliedWarranties;
using AllegroApi.Domain.AllegroShippingRates;
using AllegroApi.Domain.Validator;
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
            await ValidatorHelper.TryValidate<ImpliedWarrantiesQueryValidator, GetImpliedWarrantiesQuery>(request);

            var result = await _sellerService.GetImpliedWarrantiesAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}