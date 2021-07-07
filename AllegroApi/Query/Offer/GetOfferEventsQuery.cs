using AllegroApi.Domain.Offer.Event;
using MediatR;

namespace AllegroApi.Query.Offer
{
    /// <summary>
    /// Dziennik zdarzeń w ofertach sprzedawcy
    /// </summary>
    public class GetOfferEventsQuery : IRequest<OfferEvents>
    {
        /// <summary>
        /// from - podaj id eventu, by uzyskać wszystkie eventy które nastąpiły później 
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// limit - podaj liczbę eventów, które chcesz uzyskać w odpowiedzi (domyślnie 100, max. 1000);
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// type - podaj typ eventów, które chcesz uzyskać w odpowiedzi
        /// </summary>
        public OfferEventType Type { get; set; } = OfferEventType.NONE;
        
        public string Authorization { get; init; }

        public enum OfferEventType
        {
            OFFER_ACTIVATED,
            OFFER_CHANGED,
            OFFER_STOCK_CHANGED,
            OFFER_PRICE_CHANGED,
            OFFER_ENDED,
            OFFER_ARCHIVED,
            OFFER_BID_PLACED,
            OFFER_BID_CANCELED,
            NONE
        }
    }
}