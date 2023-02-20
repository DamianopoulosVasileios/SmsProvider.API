using SmsProvider.API.Models;

namespace SmsProvider.API.Interfaces
{
    public interface ISmsVendor
    {
        Task<bool> Send(Sms sms);
    }
}
