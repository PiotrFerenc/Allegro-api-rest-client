using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.AllegroOffer.Upload;
using RestSharp;

namespace AllegroApi.Repository
{
    public interface IApiRepository
    {
        Task<T> SendQuery<T>(RequestQuery query);
        Task<T> SendCommand<T>(RequestCommand command);
        Task<T> Send<T>(string baseUrl,string resource, IDictionary<string, string> headers, IDictionary<string, string> parameters, Method method);
    }
}