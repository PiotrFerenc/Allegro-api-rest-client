using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AllegroApi.Domain;
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
                var request = Request(query, Method.GET);

                var response = await client.ExecuteAsync(request);

                var deserializeObject = JsonConvert.DeserializeObject<T>(response.Content);

                return deserializeObject;
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
                var request = Request(query, Method.POST);

                var json = JsonConvert.SerializeObject(query.Data, new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
                request.AddParameter("application/vnd.allegro.public.v1+json", json, ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteAsync(request);

                var deserializeObject = JsonConvert.DeserializeObject<T>(response.Content);

                return deserializeObject;
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