using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroProduct
{
    public class Category
    {
        public string Id { get; set; }
        public List<object> Similar { get; set; }
    }
}