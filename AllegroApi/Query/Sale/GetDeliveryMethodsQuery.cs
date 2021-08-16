using AllegroApi.Domain.AllegroDeliveryMethods;
using MediatR;

namespace AllegroApi.Query.Sale
{
    public class GetDeliveryMethodsQuery : AuthorizationToken , IRequest<ListOfDeliveryMethods>
    {
    }
}
