using System.Threading.Tasks;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Query;
using MediatR;

namespace AllegroApi.Command.AllegroOffer
{
    public class UpdateOfferCommand: AuthorizationToken, IRequest
    {
        public Offer Offer { get; set; }
    }
}