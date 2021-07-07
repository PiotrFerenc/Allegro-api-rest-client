namespace AllegroApi.Domain.Offer.Delivery
{
    public class Delivery
    {
        public ShippingRates ShippingRates { get; set; }
        public string HandlingTime { get; set; }
        public string AdditionalInfo { get; set; }
        public object ShipmentDate { get; set; }
    }
}