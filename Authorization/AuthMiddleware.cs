namespace rapid_news_media_news_api.Authorization;

using System.Net.Http.Headers;
using System.Text;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory)
    {
        _next = next;
        _httpClientFactory = httpClientFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
            var tokenJWT = authHeader.Parameter;

            // validate JWT token with user service and attach user to http context
            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://localhost:7126/api/auth/validate")
            {
                Headers =
            {
                { "Authorization", authHeader.ToString() }
            }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            context.Items["Authenticated"] = httpResponseMessage.IsSuccessStatusCode ? true : false;

        }
        catch
        {
            // do nothing if invalid auth header
            // user is not attached to context so request won't have access to secure routes
        }

        await _next(context);
    }
}