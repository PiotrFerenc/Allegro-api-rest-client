using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroReturnPolicies;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class ReturnPoliciesHandler: IRequestHandler<ReturnPoliciesQuery, ReturnPolicies>
    {
        private readonly ISaleService _sellerService;

        public ReturnPoliciesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<ReturnPolicies> Handle(ReturnPoliciesQuery request, CancellationToken cancellationToken)
        {
            var validator = new ReturnPoliciesQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _sellerService.GetReturnPoliciesAsync(request.Authorization,request.SellerId);

            return result;
        }
    }
}