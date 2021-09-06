using AllegroApi.Domain.AllegroDeliveryMethods;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class DeliveryMethodsQuery : AuthorizationToken , IRequest<ListOfDeliveryMethods>
    {
    }
}
