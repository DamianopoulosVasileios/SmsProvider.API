namespace SmsProvider.API.Interfaces
{
    public interface ISMSVendorFactory
    {
        ISmsVendor Create(string phoneNumber);
    }
}
