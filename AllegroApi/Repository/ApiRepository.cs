using System;
using System.Collections.Generic;
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

        public async Task<UploadImageResult> UploadImage(ImageRequestCommand command)
        {
            var client = new RestClient("https://upload.allegro.pl/sale/images")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "image/png");
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");
            request.AddHeader("Authorization", "Bearer " +command.Authorization);

            request.AddParameter("image/png", command.Image, ParameterType.RequestBody);

            var response = await client.ExecuteAsync<UploadImageResult>(request);

            return response.Data;
        }

        public async Task<T> Send<T>(string baseUrl, string resource, IDictionary<string, string> headers, IDictionary<string, string> parameters, Method method)
        {
            var client = new RestClient(baseUrl);

            var request = new RestRequest(resource, method);
            
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key,parameter.Value);
            }
            var response = await client.ExecuteAsync<T>(request);
            
            var result = ValidateResponse<T>(response);

            return result;
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