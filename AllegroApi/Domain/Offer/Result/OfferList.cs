using System.Collections.Generic;

namespace AllegroApi.Domain.Offer.Result
{
    public class OfferList
    {
        public List<Offer> Offers { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}