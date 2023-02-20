using SmsProvider.API.Models;

namespace SmsProvider.API.Interfaces
{
    public interface ISmsRepository
    {
        Task<bool> CreateAsync(IEnumerable<Sms> sms);
    }
}
