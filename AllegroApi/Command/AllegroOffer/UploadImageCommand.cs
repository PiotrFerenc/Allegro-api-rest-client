using AllegroApi.Query;
using MediatR;

namespace AllegroApi.Command.AllegroOffer
{
    public class UploadImageCommand: AuthorizationToken, IRequest<string>
    {
        public byte[] File { get; set; }
    }
    
}