using MediatR;

namespace AllegroApi.Query.Account.AllegroAuth
{
    public class GetVerificationUriCompleteCommand : IRequest<(string url, string deviceCode)>
    {
        public string ClientId { get; set; }
        public string AuthKey { get; set; }
    }
}