using System.Net.Http.Json;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ISearchService
{
    Task<IEnumerable<string>> SearchByUserName(string userName);
}

public class SearchService : ISearchService
{
    private HttpClient _httpClient;

    public SearchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<string>> SearchByUserName(string userName)
    {
        var userNames = await _httpClient.GetFromJsonAsync<List<string>>($"SearchByUserName?name={userName}");
        return userNames!;
    }
}