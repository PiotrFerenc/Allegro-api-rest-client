using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.Offer.Event;
using AllegroApi.Domain.Offer.Result;
using AllegroApi.Extensions;
using AllegroApi.Query.Offer;
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

        public async Task<Domain.Offer.Offer> GetOfferByIdAsync(string authorization, string offerId)
        {
            var result = await _apiRepository.SendQuery<Domain.Offer.Offer>(new RequestQuery()
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

        public async Task<OfferEvents> GetOfferEventsAsync(string authorization, string @from, int limit, GetOfferEventsQuery.OfferEventType type)
        {
            var uri = new Uri($"https://api.allegro.pl/sale/offer-events");

            if (!string.IsNullOrEmpty(@from))
            {
                uri = uri.AddParameter("from", @from);
            }

            if (limit > 0)
            {
                uri = uri.AddParameter("limit", limit.ToString());
            }

            if (type != GetOfferEventsQuery.OfferEventType.NONE)
            {
                uri = uri.AddParameter("type", type.ToString());
            }


            var result = await _apiRepository.SendQuery<OfferEvents>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = "GET"
            });

            if (result.IsFailed)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Message)));
            }

            return result.Value;
        }

        public async Task<List<Domain.Offer.Offer>> GetOffersAsync(string authorization, PublicationStatus publicationStatus)
        {
            var offersStatus = publicationStatus.ToString().ToUpper();
            var url = new Uri($"https://api.allegro.pl/sale/offers");
            url = url.AddParameter("limit", "1000");
            url = url.AddParameter("publication.status", offersStatus);

            var firstOfferPage = await _apiRepository.SendQuery<OfferList>(new RequestQuery()
            {
                Uri = url,
                Authorization = authorization,
                Method = "GET"
            });
            
            if (firstOfferPage.IsFailed)
            {
                throw new Exception(string.Join(", ",firstOfferPage.Errors.Select(x => x.Message)));
            }
            
            var offers = firstOfferPage.Value;
            var result = offers.Offers;

            if (offers.TotalCount >= 1000)
            {
                var all = offers.TotalCount;
                var left = all;
                var downloaded = 1000;


                while (left > 0)
                {
                    url = new Uri($"https://api.allegro.pl/sale/offers");
                    url = url.AddParameter("limit", "1000");
                    url = url.AddParameter("offset", downloaded.ToString());
                    url = url.AddParameter("publication.status", offersStatus);

                    var offerPage = await _apiRepository.SendQuery<OfferList>(new RequestQuery()
                    {
                        Uri = url,
                        Authorization = authorization,
                        Method = "GET"
                    });


                    var pageWithOffers = offerPage.ValueOrDefault;
                    if (pageWithOffers != null)
                    {
                        result.AddRange(pageWithOffers.Offers);
                    }

                    downloaded += 1000;
                    left -= 1000;
                }
            }

            if (firstOfferPage.IsFailed)
            {
                throw new Exception(string.Join(", ", firstOfferPage.Errors.Select(x => x.Message)));
            }

            return result;
        }

    }
}