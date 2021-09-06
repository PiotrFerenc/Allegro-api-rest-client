using AllegroApi.Domain.AllegroImpliedWarranties;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class ImpliedWarrantiesQuery: AuthorizationToken, IRequest<AllegroImpliedWarranties>
    {
        public string SellerId { get; set; }
    }
}