using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.AllegroOffer.Event;
using AllegroApi.Domain.AllegroOffer.Image;
using AllegroApi.Domain.AllegroOffer.Publication;
using AllegroApi.Domain.AllegroOffer.Result;
using AllegroApi.Domain.AllegroOffer.Upload;
using AllegroApi.Extensions;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Repository;
using AllegroApi.Service.Interfaces;
using RestSharp;

namespace AllegroApi.Service
{
    public class OfferService : IOfferService
    {
        private readonly IApiRepository _apiRepository;

        public OfferService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public async Task<Offer> GetOfferByIdAsync(string authorization, string offerId)
        {
            var result = await _apiRepository.SendQuery<Offer>(new RequestQuery()
            {
                Uri = new Uri($"https://api.allegro.pl/sale/offers/{offerId}"),
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
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

            if (type != GetOfferEventsQuery.OfferEventType.None)
            {
                uri = uri.AddParameter("type", type.ToString());
            }


            var result = await _apiRepository.SendQuery<OfferEvents>(new RequestQuery()
            {
                Uri = uri,
                Authorization = authorization,
                Method = Method.GET
            });

            return result;
        }

        public async Task<List<Offer>> GetOffersAsync(string authorization, PublicationStatus publicationStatus)
        {
            var offersStatus = publicationStatus.ToString().ToUpper();
            var url = new Uri($"https://api.allegro.pl/sale/offers");
            url = url.AddParameter("limit", "1000");
            url = url.AddParameter("publication.status", offersStatus);

            var firstOfferPage = await _apiRepository.SendQuery<OfferList>(new RequestQuery()
            {
                Uri = url,
                Authorization = authorization,
                Method = Method.POST
            });


            var offers = firstOfferPage;
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
                        Method = Method.GET
                    });


                    var pageWithOffers = offerPage;
                    if (pageWithOffers != null)
                    {
                        result.AddRange(pageWithOffers.Offers);
                    }

                    downloaded += 1000;
                    left -= 1000;
                }
            }

            return result;
        }

        public async Task<Offer> CreateOffer(string authorization, NewOffer offer)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            foreach (var s in offer.Description.Sections.SelectMany(section => section.Items))
            {
                s.Content = regex.Replace(s.Content, " ");
            }

            var offerImages = offer.Images.Select(x => x.Url);

            offer.Images = new List<Image>();

            foreach (var image in offerImages)
            {
                var uploadImage = await _apiRepository.SendCommand<UploadImageResult>(new RequestCommand()
                {
                    Uri = new Uri("https://upload.allegro.pl/sale/images"),
                    Authorization = authorization,
                    Method = Method.POST,
                    Data = new
                    {
                        url = image
                    }
                });

                offer.Images.Add(new Image()
                {
                    Url = uploadImage.location
                });
            }


            var result = await _apiRepository.SendCommand<Offer>(new RequestCommand()
            {
                Uri = new Uri($"https://api.allegro.pl/sale/offers"),
                Authorization = authorization,
                Method = Method.POST,
                Data = offer
            });

            return result;
        }

        public async Task UpdateOffer(string authorization, Offer newOffer)
        {
            await _apiRepository.SendCommand<object>(new RequestCommand()
            {
                Uri = new Uri($"https://api.allegro.pl/sale/offers/" + newOffer.Id),
                Authorization = authorization,
                Method = Method.PUT,
                Data = newOffer
            });
        }

        public async Task<CommandTask> PublishOffers(string authorization, PublishOffer offers)
        {
            var result = await _apiRepository.SendCommand<CommandTask>(new RequestCommand()
            {
                Uri = new Uri($"https://api.allegro.pl/sale/offer-publication-commands/" + Guid.NewGuid().ToString()),
                Authorization = authorization,
                Method = Method.PUT,
                Data = offers
            });

            return result;
        }
    }
}