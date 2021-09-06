using AllegroApi;
using AllegroApi.Query.AllegroOffer;
using System;
using System.Threading.Tasks;
using AllegroApi.Command.AllegroOffer;
using AllegroApi.Domain.AllegroOffer;


namespace ConsoleApp
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var allegroApi = new AllegroRestClient();

            try
            {

                var auth = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MzA0NTMyNjQsInVzZXJfbmFtZSI6IjczMDI2MDA5IiwianRpIjoiMTg0M2QwMTYtOTE1Yi00YmNmLWJmMmUtMDQ1ZTc4ODczZGNlIiwiY2xpZW50X2lkIjoiY2Q0YmM4NjA3Y2M0NDM1NWFkMzhhYTZlNTY1ZmRiZjQiLCJzY29wZSI6WyJhbGxlZ3JvOmFwaTpvcmRlcnM6cmVhZCIsImFsbGVncm86YXBpOnByb2ZpbGU6d3JpdGUiLCJhbGxlZ3JvOmFwaTpzYWxlOm9mZmVyczp3cml0ZSIsImFsbGVncm86YXBpOmJpbGxpbmc6cmVhZCIsImFsbGVncm86YXBpOmNhbXBhaWducyIsImFsbGVncm86YXBpOmRpc3B1dGVzIiwiYWxsZWdybzphcGk6YmlkcyIsImFsbGVncm86YXBpOnNhbGU6b2ZmZXJzOnJlYWQiLCJhbGxlZ3JvOmFwaTpvcmRlcnM6d3JpdGUiLCJhbGxlZ3JvOmFwaTphZHMiLCJhbGxlZ3JvOmFwaTpwYXltZW50czp3cml0ZSIsImFsbGVncm86YXBpOnNhbGU6c2V0dGluZ3M6d3JpdGUiLCJhbGxlZ3JvOmFwaTpwcm9maWxlOnJlYWQiLCJhbGxlZ3JvOmFwaTpyYXRpbmdzIiwiYWxsZWdybzphcGk6c2FsZTpzZXR0aW5nczpyZWFkIiwiYWxsZWdybzphcGk6cGF5bWVudHM6cmVhZCIsImFsbGVncm86YXBpOm1lc3NhZ2luZyJdLCJhbGxlZ3JvX2FwaSI6dHJ1ZX0.OH6a-RPYGfCcam-vECnOEs5Pnyk_JvjvG15aQ6DKSmSYpY5jLIgSY_-uLQbf5cafQJHs93ZPQUgBCslBElLQ07ZKh2-r0V14HqLe_hIPpG5noqnToW8MdEhXg4pYvl4ZeGbXSGQTCnJTUVx314vB7hFEN5rDvHinJ31ybLJPNQb90yiWrR9zLLMQbeP0zlrHXBOyIPsKQSidHkNSAoQs4wln-DkoS8f8ZLALXI0zyBK8oUiwKbDBeBja_KK8uLZX_hxw7z9_ZakC3TptQ1eKOJnzz2LWVNfm7wAfHdxFM1v5cluh9pDnpr6_e7FXBgnO1Nm_NVcCAKN079IvRRtLrA";
                
                var offer = await allegroApi.Query(new OfferByIdQuery()
                {
                    Authorization = auth,
                   OfferId = "11077869431"
                });

                Console.WriteLine(offer.Name);
                
                var result = await allegroApi.Query(new CreateDraftOfferCommand()
                {
                    Authorization = auth,
                    Offer = new NewOffer(offer)
                    
                });

                Console.WriteLine(result);
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}