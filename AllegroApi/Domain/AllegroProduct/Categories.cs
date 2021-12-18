using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroProduct
{
    public class Categories
    {
        public List<Subcategory> Subcategories { get; set; }
        public List<Path> Path { get; set; }
    }
}