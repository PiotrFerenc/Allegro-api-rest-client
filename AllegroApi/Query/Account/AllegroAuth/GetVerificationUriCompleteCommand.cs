using MediatR;

namespace AllegroApi.Query.Account.AllegroAuth
{
    public class GetVerificationUriCompleteCommand : IRequest<string>
    {
        public string ClientId { get; set; }
        public string AuthKey { get; set; }
    }
}