using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Account.AllegroAuth;
using AllegroApi.Service.Interfaces;
using FluentValidation;
using MediatR;

namespace AllegroApi.Handler.Account
{
    public class GetVerificationUriCompleteHandler : IRequestHandler<GetVerificationUriCompleteCommand, string>
    {
        private readonly IAllegroAuthService _allegroAuthService;

        public GetVerificationUriCompleteHandler(IAllegroAuthService allegroAuthService)
        {
            _allegroAuthService = allegroAuthService;
        }

        public async Task<string> Handle(GetVerificationUriCompleteCommand request, CancellationToken cancellationToken)
        {
            await ValidatorHelper.TryValidate<GetVerificationUriCompleteValidator, GetVerificationUriCompleteCommand>(request);


            var deviceCode = await _allegroAuthService.GetDeviceCode(request.ClientId, request.AuthKey);

            return deviceCode.verification_uri_complete;
        }
    }
}