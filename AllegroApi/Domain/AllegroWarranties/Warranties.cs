using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroWarranties
{
    public class Warranties
    {
        public int Count { get; set; }
        public List<Warranty> warranties { get; set; }
    }
}