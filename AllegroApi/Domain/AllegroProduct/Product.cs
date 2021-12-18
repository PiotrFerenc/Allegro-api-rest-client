using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroProduct
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<Image> Images { get; set; }
        public Description Description { get; set; }
    }
}