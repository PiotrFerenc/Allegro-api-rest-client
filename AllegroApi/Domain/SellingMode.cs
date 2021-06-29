namespace AllegroApi.Domain
{
    public class SellingMode
    {
        public string Format { get; set; }
        public Price Price { get; set; }
        public object StartingPrice { get; set; }
        public object MinimalPrice { get; set; }
        public object NetPrice { get; set; }
    }
}