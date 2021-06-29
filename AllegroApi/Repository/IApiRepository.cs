using System.Threading.Tasks;
using AllegroApi.Domain;
using FluentResults;

namespace AllegroApi.Repository
{
    public interface IApiRepository 
    {
        Task<Result<T>> SendQuery<T>(RequestQuery query);
    }
}