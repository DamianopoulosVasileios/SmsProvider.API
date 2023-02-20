using SmsProvider.API.Interfaces;

namespace SmsProvider.API.Models
{
    public class Sms : ISms
    {
        public Guid Id { get; }
        public string PhoneNumber { get; }
        public string Message { get; }

        public Sms(string phoneNumber, string message)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            Message = message;
        }
    }
}
