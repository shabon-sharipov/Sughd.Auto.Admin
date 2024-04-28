using System.Net.Http.Headers;

namespace Sughd.Auto.Admin.Services.HelperModels;

public static class SetToke
{
    public static void SetTokeToHeaderRequest(HttpClient httpClient, string authToken)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
    }
}