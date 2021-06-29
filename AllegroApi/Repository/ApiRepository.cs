using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AllegroApi.Domain;
using FluentResults;
using Newtonsoft.Json;

namespace AllegroApi.Repository
{
    public class ApiRepository : IApiRepository
    {
        public async Task<Result<T>> SendQuery<T>(RequestQuery query)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(query.Uri);
            httpWebRequest.ContentType = "application/vnd.allegro.public.v1+json";
            httpWebRequest.Accept = "application/vnd.allegro.public.v1+json";
            httpWebRequest.Headers.Add("Authorization", "Bearer " +query.Authorization);

            httpWebRequest.Method = query.Method;

            // await using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            // {
            //     await streamWriter.WriteAsync(JsonConvert.SerializeObject(query.Data));
            // }

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var result = await streamReader.ReadToEndAsync();

                if (string.IsNullOrEmpty(result)) return Result.Fail("Empty result.");

                var deserializeObject = JsonConvert.DeserializeObject<T>(result);

                return Result.Ok<T>(deserializeObject);
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}