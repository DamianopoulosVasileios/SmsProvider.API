namespace SmsProvider.API.Interfaces
{
    public interface ISmsService
    {
        Task<bool> RouteToVendor(string phoneNumber, string message);
    }
}
