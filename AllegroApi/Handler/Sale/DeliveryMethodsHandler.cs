using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroDeliveryMethods;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
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
            await ValidatorHelper.TryValidate<DeliveryMethodsQueryValidator, GetDeliveryMethodsQuery>(request);

            var result = await _sellerService.GetDeliveryMethodsAsync(request.Authorization);

            return result;
        }
    }
}