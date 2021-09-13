using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.AllegroOffer.Upload;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace AllegroApi.Repository
{
    public class ApiRepository : IApiRepository
    {
        public string ContentType = "application/vnd.allegro.public.v1+json";
        public string Accept = "application/vnd.allegro.public.v1+json";

        public async Task<T> SendQuery<T>(RequestQuery query)
        {
            try
            {
                var client = new RestClient(query.Uri) {Timeout = -1};
                var request = Request(query, query.Method);

                var response = await client.ExecuteAsync(request);

                var result = ValidateResponse<T>(response);

                return result;
                //TODO: Logging ex
            }
            catch (WebException we)
            {
                throw new WebException(we.Message);
            }
            catch (Exception e)
            {
                throw new WebException(e.Message);
            }
        }
        public async Task<T> SendCommand<T>(RequestCommand query)
        {
            try
            {
                var client = new RestClient(query.Uri) {Timeout = -1};
                var request = Request(query, query.Method);

                var json = JsonConvert.SerializeObject(query.Data, new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
                request.AddParameter("application/vnd.allegro.public.v1+json", json, ParameterType.RequestBody);

                var response = await client.ExecuteAsync(request);

                var result = ValidateResponse<T>(response);


                return result;
                //TODO: Logging ex
            }
            catch (WebException we)
            {
                throw new WebException(we.Message);
            }
            catch (Exception e)
            {
                throw new WebException(e.Message);
            }
        }

        private static T ValidateResponse<T>(IRestResponse response)
        {
            var allegroError = JsonConvert.DeserializeObject<AllegroErrorResponse>(response.Content);
            if (allegroError != null && (!string.IsNullOrEmpty(allegroError.Error) || !string.IsNullOrEmpty(allegroError.ErrorDescription)))
            {
                throw new Exception(allegroError.Error);
            }

            var deserializeObject = JsonConvert.DeserializeObject<T>(response.Content);
            return deserializeObject;
        }
        private static RestRequest Request(IRequestAllegro query, Method method)
        {
            var request = new RestRequest(method);

            request.AddHeader("Content-Type", "application/vnd.allegro.public.v1+json");
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");
            request.AddHeader("Authorization", "Bearer " + query.Authorization);
            return request;
        }
    }
}