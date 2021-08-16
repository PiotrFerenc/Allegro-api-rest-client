namespace AllegroApi.Domain.AllegroDeliveryMethods
{
    public class ShippingRatesConstraints
    {
        public bool Allowed { get; set; }
        public MaxQuantityPerPackage MaxQuantityPerPackage { get; set; }
        public FirstItemRate FirstItemRate { get; set; }
        public NextItemRate NextItemRate { get; set; }
        public ShippingTime ShippingTime { get; set; }
    }
}
