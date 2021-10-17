using System.Threading.Tasks;
using AllegroApi.Domain.Auth;

namespace AllegroApi.Service.Interfaces
{
    public interface IAllegroAuthService
    {
        Task<DeviceCode> GetDeviceCode(string clientId, string authorization);
        Task<(bool isComfirmed, DeviceAuthToken deviceAuthToken)> IsConfirmed(string requestDeviceCodeId, string requestAuthorization);
    }
}