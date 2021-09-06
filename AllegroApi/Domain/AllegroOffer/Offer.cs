using System;
using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer.Image;
using AllegroApi.Domain.AllegroOffer.Price;

namespace AllegroApi.Domain.AllegroOffer
{
    public class Offer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category.Category Category { get; set; }
        public SaleInfo SaleInfo { get; set; }
        public Stats.Stats Stats { get; set; }
        public Product Product { get; set; }
        public List<Parameter.Parameter> Parameters { get; set; }
        public object CustomParameters { get; set; }
        public Description.Description Description { get; set; }
        public object CompatibilityList { get; set; }
        public object TecdocSpecification { get; set; }
        public List<Image.Image> Images { get; set; }
        public SellingMode.SellingMode SellingMode { get; set; }
        public object Tax { get; set; }
        public Stock.Stock Stock { get; set; }
        public Publication.Publication Publication { get; set; }
        public Delivery.Delivery Delivery { get; set; }
        public Payments.Payments Payments { get; set; }
        public object Discounts { get; set; }
        public AfterSalesServices.AfterSalesServices AfterSalesServices { get; set; }
        public AdditionalServices.AdditionalServices AdditionalServices { get; set; }
        public object SizeTable { get; set; }
        public object FundraisingCampaign { get; set; }
        public Promotion.Promotion Promotion { get; set; }
        public Location.Location Location { get; set; }
        public External.External External { get; set; }
        public List<object> Attachments { get; set; }
        public object Contact { get; set; }
        public Validation.Validation Validation { get; set; }
        public object Ean { get; set; }
        public PrimaryImage PrimaryImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class OfferId
    {
        public OfferId(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}