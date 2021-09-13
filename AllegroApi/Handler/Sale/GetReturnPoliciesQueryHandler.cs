using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroReturnPolicies;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class ReturnPoliciesHandler: IRequestHandler<GetReturnPoliciesQuery, ReturnPolicies>
    {
        private readonly ISaleService _sellerService;

        public ReturnPoliciesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<ReturnPolicies> Handle(GetReturnPoliciesQuery request, CancellationToken cancellationToken)
        {

            await ValidatorHelper.TryValidate<ReturnPoliciesQueryValidator, GetReturnPoliciesQuery>(request);

            var result = await _sellerService.GetReturnPoliciesAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}