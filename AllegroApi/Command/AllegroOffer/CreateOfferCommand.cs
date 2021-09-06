using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Query;
using MediatR;

namespace AllegroApi.Command.AllegroOffer
{
    public class CreateDraftOfferCommand : AuthorizationToken, IRequest<string>
    {
        public NewOffer Offer { get; set; }
    }
}