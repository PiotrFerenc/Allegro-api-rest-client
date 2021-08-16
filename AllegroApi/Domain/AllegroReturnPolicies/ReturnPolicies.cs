using System.Collections.Generic;

namespace AllegroApi.Domain.AllegroReturnPolicies
{
    public class ReturnPolicies
    {
        public int Count { get; set; }
        public List<ReturnPolicy> returnPolicies { get; set; }
    }
}