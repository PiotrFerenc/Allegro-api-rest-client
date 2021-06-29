using System;
using System.Collections.Generic;

namespace AllegroApi.Domain
{
    public class Offer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public object Product { get; set; }
        public List<Parameter> Parameters { get; set; }
        public object CustomParameters { get; set; }
        public Description Description { get; set; }
        public object CompatibilityList { get; set; }
        public object TecdocSpecification { get; set; }
        public List<Image> Images { get; set; }
        public SellingMode SellingMode { get; set; }
        public object Tax { get; set; }
        public Stock Stock { get; set; }
        public Publication Publication { get; set; }
        public Delivery Delivery { get; set; }
        public Payments Payments { get; set; }
        public object Discounts { get; set; }
        public AfterSalesServices AfterSalesServices { get; set; }
        public object AdditionalServices { get; set; }
        public object SizeTable { get; set; }
        public object FundraisingCampaign { get; set; }
        public Promotion Promotion { get; set; }
        public Location Location { get; set; }
        public object External { get; set; }
        public List<object> Attachments { get; set; }
        public object Contact { get; set; }
        public Validation Validation { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}