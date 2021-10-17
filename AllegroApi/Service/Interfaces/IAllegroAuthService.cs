using System.Collections.Generic;
using System.Threading.Tasks;
using AllegroApi.Domain.Auth;
using AllegroApi.Repository;
using RestSharp;

namespace AllegroApi.Service.Interfaces
{
    public interface IAllegroAuthService
    {
        Task<DeviceCode> GetDeviceCode(string clientId, string authorization);
    }

    public class AllegroAuthService : IAllegroAuthService
    {
        private readonly IApiRepository _apiRepository;

        public AllegroAuthService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }


        public async Task<DeviceCode> GetDeviceCode(string clientId, string authorization)
        {
            var parameters = new Dictionary<string, string>()
            {
                {"client_id", clientId}
            };

            var headers = new Dictionary<string, string>()
            {
                {"Authorization", "Basic "+authorization},
                {"Content-Type", "application/x-www-form-urlencoded"}
            };


            var deviceCode = await _apiRepository.Send<DeviceCode>("https://allegro.pl", "auth/oauth/device", headers,
                parameters, Method.POST);

            return deviceCode;
        }
    }
}