using AllegroApi.Domain.AllegroOffer.Event;
using AllegroApi.Domain.AllegroProduct;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    public class GetProductsByNameQuery : AuthorizationToken,
        IRequest<(AllegroProduct products, Product bestProductByName)>
    {
        public string Name { get; set; }
    }
}