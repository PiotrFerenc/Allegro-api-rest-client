using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroProduct
{
    public class AllegroProduct
    {
        public List<Product> Products { get; set; }
        public Categories Categories { get; set; }
        public List<object> Filters { get; set; }
        public object NextPage { get; set; }
    }
}