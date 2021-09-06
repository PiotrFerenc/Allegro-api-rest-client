using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroOffer.Publication
{
    public class OfferCriteria
    {
        public List<OfferId> Offers { get; set; }
        public string Type { get; set; }
    }
}