using System;
using System.Threading.Tasks;
using AllegroApi.Domain;
using AllegroApi.Domain.AllegroOffer.Upload;

namespace AllegroApi.Repository
{
    public interface IApiRepository
    {
        Task<T> SendQuery<T>(RequestQuery query);
        Task<T> SendCommand<T>(RequestCommand command);
    }
}