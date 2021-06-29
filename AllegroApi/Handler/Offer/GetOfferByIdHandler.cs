using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Offer;
using AllegroApi.Service.Offer;
using MediatR;

namespace AllegroApi.Handler.Offer
{
    public class GetOfferByIdHandler : IRequestHandler<GetOfferByIdQuery, Domain.Offer>
    {
        private readonly IOfferService _offerService;

        public GetOfferByIdHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<Domain.Offer> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOfferByIdQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _offerService.GetOfferById(request.Authorization, request.OfferId);

            return result;
        }
    }
}