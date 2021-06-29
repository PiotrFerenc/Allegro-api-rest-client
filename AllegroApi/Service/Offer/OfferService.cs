using System;
using System.Linq;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Repository;

namespace AllegroApi.Service.Offer
{
    public class OfferService : IOfferService
    {
        private readonly IApiRepository _apiRepository;

        public OfferService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<Domain.Offer> GetOfferById(string authorization, string offerId)
        {
            var result = await _apiRepository.SendQuery<Domain.Offer>(new RequestQuery()
            {
                Uri = new Uri($"https://api.allegro.pl/sale/offers/{offerId}"),
                Authorization = authorization,
                Method = "GET"
            });

            if (result.IsFailed)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Message)));
            }
            
            return result.Value;
        }
    }
}