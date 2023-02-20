using SmsProvider.API.Interfaces;
using SmsProvider.API.Models;
using SmsProvider.API.Static;

namespace SmsProvider.API.Vendors
{
    public class SMSVendorGR : ISmsVendor
    {
        private readonly ISmsRepository _smsRepository;
        public SMSVendorGR(ISmsRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        public async Task<bool> Send(Sms sms)
        {
            if (!SmsValidations.CheckSmsMaxCharacters(sms.Message.Length))
                throw new Exception("Message length is higher than the limit");

            if (!SmsValidations.CheckGreekCharacters(sms.Message))
                throw new Exception("Message must have greek characters only");

            var result = await _smsRepository.CreateAsync(new List<Sms> { sms }.AsEnumerable());
            return result;
        }
    }

}
