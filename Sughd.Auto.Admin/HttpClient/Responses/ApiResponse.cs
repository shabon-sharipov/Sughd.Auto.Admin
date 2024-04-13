using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Sughd.Auto.Admin.HttpClient.Responses;

public class ApiResponse
{
    public bool Success { get; set; }
    public HttpStatusCode? HttpStatusCode { get; set; }
    public BadRequestResponse? BadRequestResponse { get; protected set; }

    public static async Task<ApiResponse> BuildFromHttpResponse(HttpResponseMessage responseMessage)
    {
        var apiResponse = new ApiResponse
        {
            Success = true,
            HttpStatusCode = responseMessage.StatusCode
        };
        if (responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            apiResponse.BadRequestResponse = await responseMessage.Content.ReadFromJsonAsync<BadRequestResponse>();
        }

        return apiResponse;
    }
}


public class ApiResponse<T> : ApiResponse
{
    public T? Result { get; private set; }

    public static async Task<ApiResponse<T>> BuildFromHttpResponseAsync(HttpResponseMessage responseMessage)
    {
        var apiResponse = new ApiResponse<T>
        {
            HttpStatusCode = responseMessage.StatusCode,
            Success = true
        };

        if (responseMessage.IsSuccessStatusCode)
            apiResponse.Result = await responseMessage.Content.ReadFromJsonAsync<T>();
        else
            apiResponse.BadRequestResponse = await responseMessage.Content.ReadFromJsonAsync<BadRequestResponse>();

        return apiResponse;
    }
}

public class BadRequestResponse
{
    [JsonPropertyName("status")] public int? Status { get; set; }

    [JsonPropertyName("detail")] public string? Detail { get; set; }

    [JsonPropertyName("instance")] public string? Instance { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("errors")] public Dictionary<string, List<string>>? Errors { get; set; }
}