using System.Net.Http;

namespace APIGateway.HttpClients
{
    public class BaseMicroservicesHttpClient : HttpClient
    {
        public BaseMicroservicesHttpClient()
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-protobuf"));
        }
    }
}
