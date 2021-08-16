using System.Collections.Generic;

namespace AllegroApi.Domain.ImpliedWarranties
{
    public class Warranties
    {
        public int Count { get; set; }
        public List<ImpliedWarranty> ImpliedWarranties { get; set; }
    }


}