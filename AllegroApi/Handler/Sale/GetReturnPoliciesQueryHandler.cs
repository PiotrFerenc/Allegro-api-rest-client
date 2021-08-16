using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroReturnPolicies;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Sale;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class GetReturnPoliciesHandler: IRequestHandler<GetReturnPoliciesQuery, ReturnPolicies>
    {
        private readonly ISaleService _sellerService;

        public GetReturnPoliciesHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<ReturnPolicies> Handle(GetReturnPoliciesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetReturnPoliciesQueryValidator();
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