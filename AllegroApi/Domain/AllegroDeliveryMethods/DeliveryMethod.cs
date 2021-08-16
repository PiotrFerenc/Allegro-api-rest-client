using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllegroApi.Domain.AllegroDeliveryMethods
{

    public class DeliveryMethod
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PaymentPolicy { get; set; }
        public bool AllegroEndorsed { get; set; }
        public ShippingRatesConstraints ShippingRatesConstraints { get; set; }
    }
}
