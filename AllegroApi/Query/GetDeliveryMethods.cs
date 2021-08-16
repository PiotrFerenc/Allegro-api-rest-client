using AllegroApi.Domain.AllegroDeliveryMethods;
using MediatR;

namespace AllegroApi.Query
{
    public class GetDeliveryMethodsQuery : AuthorizationToken , IRequest<ListOfDeliveryMethods>
    {
    }
}
