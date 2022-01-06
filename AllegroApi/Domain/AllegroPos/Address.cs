namespace AllegroApi.Domain.Pos
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string state { get; set; }
        public string countryCode { get; set; }
        public Coordinates coordinates { get; set; }
    }
}
