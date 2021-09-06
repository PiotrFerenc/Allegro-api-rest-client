using System;
using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroOffer.Publication
{
    public class PublishOffer
    {
        public Publication Publication { get; set; }
        public List<OfferCriteria> OfferCriteria { get; set; }

        public PublishOffer(List<OfferId> offers, string action = "ACTIVATE")
        {
            Publication = new Publication()
            {
                Action = action,
                ScheduledFor = DateTime.Now.AddMinutes(2)
            };

            OfferCriteria = new List<OfferCriteria>()
            {
                {
                    new OfferCriteria()
                    {
                        Offers = offers,
                        Type = "CONTAINS_OFFERS"
                    }
                }
            };
        }
    }
}