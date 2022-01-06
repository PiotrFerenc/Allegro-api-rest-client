using AllegroApi.Domain.Pos;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class GetPosQuery : AuthorizationToken, IRequest<Pos>
    {
        public string sellerId { get; set; }
    }
}
