using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.AllegroOffer.Publication;
using AllegroApi.Query;
using MediatR;

namespace AllegroApi.Command.AllegroOffer
{
    public class PublishOffersCommand : AuthorizationToken, IRequest<CommandTask>
    {
        public List<OfferId> Offers { set; get; }
    }
}