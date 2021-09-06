using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer.Image;
using AllegroApi.Domain.AllegroOffer.Price;

namespace AllegroApi.Domain.AllegroOffer
{
 
    public class NewOffer
    {
        public NewOffer()
        {

        }
        public NewOffer(Offer offer)
        {
            Name = offer.Name;
            Category = offer.Category;
            PrimaryImage = offer.PrimaryImage;
            SellingMode = offer.SellingMode;
            SaleInfo = offer.SaleInfo;
            Stats = offer.Stats;
            Stock = offer.Stock;
            AfterSalesServices = offer.AfterSalesServices;
            AdditionalServices = offer.AdditionalServices;
            External = offer.External;
            Product = offer.Product;
            Parameters = offer.Parameters;
            Ean = offer.Ean;
            Description = offer.Description;
            CompatibilityList = offer.CompatibilityList;
            Images = offer.Images;
            Delivery = offer.Delivery;
            Payments = offer.Payments;
            SizeTable = offer.SizeTable;
            Promotion = offer.Promotion;
            Location = offer.Location;
            Attachments = offer.Attachments;
            Contact = offer.Contact;
        }

        public string Name { get; set; }
        public Category.Category Category { get; set; }
        public PrimaryImage PrimaryImage { get; set; }
        public SellingMode.SellingMode SellingMode { get; set; }
        public SaleInfo SaleInfo { get; set; }
        public Stats.Stats Stats { get; set; }
        public Stock.Stock Stock { get; set; }
        public AfterSalesServices.AfterSalesServices AfterSalesServices { get; set; }
        public AdditionalServices.AdditionalServices AdditionalServices { get; set; }
        public External.External External { get; set; }
        public object Product { get; set; }
        public List<Parameter.Parameter> Parameters { get; set; }
        public object Ean { get; set; }
        public Description.Description Description { get; set; }
        public object CompatibilityList { get; set; }
        public List<Image.Image> Images { get; set; }
        public Delivery.Delivery Delivery { get; set; }
        public Payments.Payments Payments { get; set; }
        public object SizeTable { get; set; }
        public Promotion.Promotion Promotion { get; set; }
        public Location.Location Location { get; set; }
        public List<object> Attachments { get; set; }
        public object Contact { get; set; } 
    }
}