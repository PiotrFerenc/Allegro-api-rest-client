using System;

namespace AllegroApi.Domain.Offer.Event
{
    public class OfferEvent
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public DateTime OccurredAt { get; set; }
        public OfferId Offer { get; set; }
    }
}