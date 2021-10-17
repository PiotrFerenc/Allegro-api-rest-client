using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.Auth;
using AllegroApi.Domain.Validator;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Account.AllegroAuth;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Account
{
    public class CheckAccountConfirmationHandler : IRequestHandler<CheckAccountConfirmationCommand, (bool isComfirmed, DeviceAuthToken deviceAuthToken)>
    {
        private readonly IAllegroAuthService _allegroAuthService;

        public CheckAccountConfirmationHandler(IAllegroAuthService allegroAuthService)
        {
            _allegroAuthService = allegroAuthService;
        }

        public async Task<(bool isComfirmed, DeviceAuthToken deviceAuthToken)> Handle(CheckAccountConfirmationCommand request,
            CancellationToken cancellationToken)
        {
            await ValidatorHelper
                .TryValidate<CheckAccountConfirmationValidator, CheckAccountConfirmationCommand>(request);

            var deviceCode = await _allegroAuthService.IsConfirmed(request.DeviceCodeId, request.Authorization);

            return deviceCode;
        }
    }
}