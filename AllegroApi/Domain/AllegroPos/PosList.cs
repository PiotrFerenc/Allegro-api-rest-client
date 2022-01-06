
using System;
using System.Collections.Generic;

namespace AllegroApi.Domain.Pos
{
    public class PosList
    {
        public string id { get; set; }
        public object externalId { get; set; }
        public string name { get; set; }
        public Seller seller { get; set; }
        public string type { get; set; }
        public Address address { get; set; }
        public List<Location> locations { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public List<OpenHour> openHours { get; set; }
        public object serviceTime { get; set; }
        public List<Payment> payments { get; set; }
        public string confirmationType { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
