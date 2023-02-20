using SmsProvider.API.Interfaces;
using SmsProvider.API.Models;
using SmsProvider.API.Static;

namespace SmsProvider.API.Vendors
{
    public class SMSVendorCY : ISmsVendor
    {
        private readonly ISmsRepository _smsRepository;
        public SMSVendorCY(ISmsRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        public async Task<bool> Send(Sms sms)
        {
            if (!SmsValidations.CheckSmsMaxCharacters(sms.Message.Length))
                throw new Exception("Message length is higher than the limit");

            var partial_messages = SmsValidations.GetPartialMultipleSms(sms.Message);
            var smsList = CreateSmsList(partial_messages, sms);

            var result = await _smsRepository.CreateAsync(smsList);
            return result;
        }

        private IEnumerable<Sms> CreateSmsList(IEnumerable<string> partial_messages, Sms sms)
        {
            return partial_messages.Select(partial_message => new Sms(sms.PhoneNumber, partial_message));
        }
    }
}
