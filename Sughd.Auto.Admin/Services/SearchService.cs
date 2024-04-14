using System.Net.Http.Json;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ISearchService
{
    Task<IEnumerable<UserInfoForSaleCarResponseModel>> SearchByUserName(string phoneNumber);
}

public class SearchService : ISearchService
{
    private HttpClient _httpClient;

    public SearchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<UserInfoForSaleCarResponseModel>> SearchByUserName(string phoneNumber)
    {
        var userNames = await _httpClient.GetFromJsonAsync<List<UserInfoForSaleCarResponseModel>>($"SearchByUserPhoneNumber?phoneNumber={phoneNumber}");
        return userNames!;
    }
}