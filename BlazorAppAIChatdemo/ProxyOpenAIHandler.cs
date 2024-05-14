namespace BlazorAppAIChatdemo
{
    public class ProxyOpenAIHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri != null && request.RequestUri.Host.Equals("api.openai.com", StringComparison.OrdinalIgnoreCase))
            {
                // your proxy url
                //
                request.RequestUri = new Uri($"http://localhost:3333{request.RequestUri.PathAndQuery}");
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
