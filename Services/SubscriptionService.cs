using System.Diagnostics;
using System.Net.Http.Json;
using Subscriptions.Web.Requests;

public sealed class SubscriptionService
{
    private readonly HttpClient _http;

    public SubscriptionService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<string?> TestServerApi()
    {
        try
        {
            var response = await _http.GetAsync("/ApiTest/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.InnerException?.Message ?? ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<SubscriptionType>> GetSubscriptionTypesAsync()
    {
        var result = await _http.GetFromJsonAsync<IEnumerable<SubscriptionType>>("/SubscriptionTypes/");
        return result ?? Enumerable.Empty<SubscriptionType>();
    }
}
