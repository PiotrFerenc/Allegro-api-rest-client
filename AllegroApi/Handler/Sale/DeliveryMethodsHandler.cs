using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroDeliveryMethods;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Sale;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class DeliveryMethodsHandler: IRequestHandler<GetDeliveryMethodsQuery, ListOfDeliveryMethods>
    {
        private readonly ISaleService _sellerService;

        public DeliveryMethodsHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }


        public async Task<ListOfDeliveryMethods> Handle(GetDeliveryMethodsQuery request, CancellationToken 
        cancellationToken)
        {
            var validator = new GetDeliveryMethodsQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _sellerService.GetDeliveryMethodsAsync(request.Authorization);

            return result;
        }
    }
}