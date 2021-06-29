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
                var result = await allegroApi.Query(new GetOfferByIdQuery()
                {
                    OfferId = "10862116958",
                    Authorization = "authcode"
                });
                
                Console.WriteLine(result.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}