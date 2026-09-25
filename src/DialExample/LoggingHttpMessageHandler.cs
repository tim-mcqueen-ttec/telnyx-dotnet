


public class LoggingHttpMessageHandler : DelegatingHandler
{
    public LoggingHttpMessageHandler()
    {
        InnerHandler = new HttpClientHandler();        
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($@"
Request: 

    Method: {request.Method}
    Request Uri: {request.RequestUri}
    Headers: 
    {string.Join(",\n  ", request.Headers.Select(h => h.Key + "=" + string.Join(";", h.Value)))}

    Body: 
    {(await request.Content.ReadAsStringAsync()) ?? "<no body>"}


        ");
        var response = await base.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Request failed with status code: " + response.StatusCode);
            return response;
        }
        Console.WriteLine($@"
Response: 

    Status Code: {response.StatusCode}
    Headers: 
    {string.Join(",\n  ", response.Headers.Select(h => h.Key + "=" + string.Join(";", h.Value)))}

    Body: 
    {(await response.Content.ReadAsStringAsync()) ?? "<no body>"}

        ");

        return response;
    }
}