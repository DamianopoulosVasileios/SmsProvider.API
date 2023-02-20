namespace SmsProvider.API.Static
{
    public class ApiException : Exception
    {
        public HttpResponseMessage Response { get; }

        public ApiException(HttpResponseMessage response) : base($"Request failed with status code {response.StatusCode}")
        {
            Response = response;
        }
    }
}
