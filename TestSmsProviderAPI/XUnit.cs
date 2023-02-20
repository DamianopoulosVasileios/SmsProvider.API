using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace TestSmsProviderAPI
{
    public class XUnit
    {
        private static string BigMessage => new('*', 481);
        private static readonly string SmsAPIUri = "/SendSMS";

        [Theory]
        [InlineData("?phoneNumber=+306971234567&message=englishmessage")]
        [InlineData("?phoneNumber=306971234567&message=englishmessageΜΕΕΛΛΗΝΙΚΑ")]
        [InlineData("?phoneNumber=306971234567&message=ΜΟΝΟΕΛΛΗΝΙΚΑ")]
        [InlineData("?phoneNumber=306971234567&message=ΜΟΝΟΕΛΛΗΝΙΚΑ_ΜΕΣΗΜΕΙΑΣΤΙΞΗΣ")]
        [InlineData("?phoneNumber=306971234567&message=" + nameof(BigMessage))]
        public async void SendSmsGreek(string sms)
        {
            using var app = new WebApplicationFactory<Program>();
            using var client = app.CreateClient();
            await RunTest(SmsAPIUri, sms, client);
        }

        [Theory]
        [InlineData("?phoneNumber=+3576971234567&message=englishmessage")]
        [InlineData("?phoneNumber=3576971234567&message=")]
        [InlineData("?phoneNumber=306971234567&message=" + nameof(BigMessage))]
        public async void SendSmsCyprus(string sms)
        {
            using var app = new WebApplicationFactory<Program>();
            using var client = app.CreateClient();
            await RunTest(SmsAPIUri, sms, client);
        }

        private static async Task<bool> RunTest(string api, string test, HttpClient client)
        {
            var response = (await client.PostAsync(api + test, null));
            var data = await response.Content.ReadAsStringAsync();
            var error = (data.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))[0];
            Assert.Multiple(() =>
            {
                Assert.True(HttpStatusCode.OK.Equals(response.StatusCode), error);
            });
            return true;
        }
    }
}