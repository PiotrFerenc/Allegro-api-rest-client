using AllegroApi.Domain.AllegroWarranties;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class WarrantiesQuery : AuthorizationToken , IRequest<Warranties>
    {
        public string SellerId { get; set; }
    }
}