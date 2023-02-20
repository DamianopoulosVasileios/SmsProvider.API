namespace SmsProvider.API.Static
{
    public static class DecideVendor
    {
        public static string DecideVendorMethod(string phoneNumber)
        {
            phoneNumber = phoneNumber.TrimStart('+');

            if (phoneNumber.StartsWith(((int)VendorSysNames.Greece).ToString()))
            {
                return nameof(VendorSysNames.Greece);
            }
            else if (phoneNumber.StartsWith(((int)VendorSysNames.Cyprus).ToString()))
            {
                return nameof(VendorSysNames.Cyprus);
            }
            else
            {
                return nameof(VendorSysNames.Rest);
            }
        }
    }
}
