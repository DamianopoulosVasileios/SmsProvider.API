namespace SmsProvider.API.Interfaces
{
    public interface ISms
    {
        Guid Id { get; }
        string PhoneNumber { get; }
        string Message { get; }
    }
}
