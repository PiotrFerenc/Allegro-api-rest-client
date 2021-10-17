using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllegroApi.Domain.Auth;
using AllegroApi.Repository;
using AllegroApi.Service.Interfaces;
using RestSharp;

namespace AllegroApi.Service
{
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
                {"Authorization", "Basic " + authorization},
                {"Content-Type", "application/x-www-form-urlencoded"}
            };


            var deviceCode = await _apiRepository.Send<DeviceCode>("https://allegro.pl", "auth/oauth/device", headers,
                parameters, Method.POST);

            return deviceCode;
        }

        public async Task<(bool isComfirmed, DeviceAuthToken deviceAuthToken)> IsConfirmed(string deviceCode,
            string authorization)
        {
            var parameters = new Dictionary<string, string>()
            {
                {"grant_type", "urn:ietf:params:oauth:grant-type:device_code"},
                {"device_code", deviceCode}
            };

            var headers = new Dictionary<string, string>()
            {
                {"Authorization", "Basic " + authorization},
            };

            try
            {
                var result = await _apiRepository.Send<DeviceAuthToken>("https://allegro.pl", "auth/oauth/token", headers, parameters, Method.POST);
                
                return (isComfirmed: true, deviceAuthToken: result);
            }
            catch (Exception e)
            {
                return (isComfirmed: false, deviceAuthToken: null);
            }
            
        }
    }
}