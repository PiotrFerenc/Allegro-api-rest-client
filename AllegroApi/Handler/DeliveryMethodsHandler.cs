using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroDeliveryMethods;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query;
using AllegroApi.Service.AllegroOffer;
using MediatR;

namespace AllegroApi.Handler
{
    
    public class DeliveryMethodsHandler: IRequestHandler<GetDeliveryMethodsQuery, ListOfDeliveryMethods>
    {
        private readonly IOfferService _offerService;

        public DeliveryMethodsHandler(IOfferService offerService)
        {
            _offerService = offerService;
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

            var result = await _offerService.GetDeliveryMethodsAsync(request.Authorization);

            return result;
        }
    }
}