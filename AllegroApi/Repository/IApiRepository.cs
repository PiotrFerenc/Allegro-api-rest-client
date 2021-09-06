using System.Threading.Tasks;
using AllegroApi.Domain;

namespace AllegroApi.Repository
{
    public interface IApiRepository 
    {
        Task<T> SendQuery<T>(RequestQuery query);
        Task<T> SendCommand<T>(RequestCommand query);
    }
}