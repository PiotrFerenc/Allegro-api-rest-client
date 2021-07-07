using System;
using System.Threading.Tasks;
using AllegroApi;
using AllegroApi.Query.Offer;

namespace ConsoleApp
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var allegroApi = new AllegroRestClient();

            try
            {

                var result = await allegroApi.Query(new GetOfferEventsQuery()
                {
                    Type = GetOfferEventsQuery.OfferEventType.OFFER_ACTIVATED,
                    Authorization = "auth-code",
                    Limit = 1000,
                    From = "ID-EVENTU"
                });

                foreach (var item in result.offerEvents)
                {
                    Console.WriteLine(item.Offer.Id);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}