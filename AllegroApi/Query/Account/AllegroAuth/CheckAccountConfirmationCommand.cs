using AllegroApi.Domain.Auth;
using MediatR;

namespace AllegroApi.Query.Account.AllegroAuth
{
    public class CheckAccountConfirmationCommand: IRequest<(bool isComfirmed, DeviceAuthToken deviceAuthToken)>
    {
        public string DeviceCodeId { get; set; }
        public string  Authorization { get; set; }
    }
}