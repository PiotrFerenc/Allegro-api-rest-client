using AllegroApi.Domain.AllegroDeliveryMethods;
using MediatR;

namespace AllegroApi.Query.SellerInformation
{
    public class GetDeliveryMethodsQuery : AuthorizationToken , IRequest<ListOfDeliveryMethods>
    {
    }
}
