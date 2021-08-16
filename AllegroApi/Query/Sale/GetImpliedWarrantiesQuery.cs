using AllegroApi.Domain.ImpliedWarranties;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class GetImpliedWarrantiesQuery: AuthorizationToken, IRequest<AllegroImpliedWarranties>
    {
        public string SellerId { get; set; }
    }
}