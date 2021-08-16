using AllegroApi.Domain.AllegroReturnPolicies;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class GetReturnPoliciesQuery : AuthorizationToken, IRequest<ReturnPolicies>
    {
        public string SellerId { get; set; }
    }
}