using Autofac.Features.Indexed;
using SmsProvider.API.Interfaces;
using SmsProvider.API.Static;

namespace SmsProvider.API.Factories
{
    public class SMSVendorFactory : ISMSVendorFactory
    {
        private readonly IIndex<string, ISmsVendor> _vendors;
        public SMSVendorFactory(IIndex<string, ISmsVendor> vendors)
        {
            _vendors = vendors;
        }

        public ISmsVendor Create(string phoneNumber)
        {
            var vendorSysname = DecideVendor.DecideVendorMethod(phoneNumber);

            if (_vendors.TryGetValue(vendorSysname, out var vendor))
                return vendor;

            throw new Exception("Unknown Vendor");
        }

    }
}
