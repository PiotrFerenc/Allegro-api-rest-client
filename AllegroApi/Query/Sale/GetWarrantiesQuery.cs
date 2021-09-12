using AllegroApi.Domain.AllegroWarranties;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class GetWarrantiesQuery : AuthorizationToken , IRequest<Warranties>
    {
        public string SellerId { get; set; }
    }
}