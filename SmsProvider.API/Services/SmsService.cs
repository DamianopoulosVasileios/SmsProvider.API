using SmsProvider.API.Interfaces;
using SmsProvider.API.Models;

namespace SmsProvider.API.Services
{
    public class SmsService : ISmsService
    {
        private readonly ISMSVendorFactory _smsVendorFactory;

        public SmsService(ISMSVendorFactory smsVendorFactory)
        {
            _smsVendorFactory = smsVendorFactory;
        }

        public async Task<bool> RouteToVendor(string phoneNumber, string message)
        {
            var sms = new Sms(phoneNumber, message);
            ISmsVendor smsVendor = _smsVendorFactory.Create(phoneNumber);
            return await smsVendor.Send(sms);
        }
    }
}
