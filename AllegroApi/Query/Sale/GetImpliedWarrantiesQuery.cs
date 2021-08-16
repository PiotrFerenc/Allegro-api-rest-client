using AllegroApi.Domain.ImpliedWarranties;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class GetImpliedWarrantiesQuery: AuthorizationToken, IRequest<Warranties>
    {
        public string SellerId { get; set; }
    }
}