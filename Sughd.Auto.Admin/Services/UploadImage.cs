using System.Net;
using System.Net.Http.Json;
using FluentFTP;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace Sughd.Auto.Admin.Services;

public interface IUploadImageService
{
    Task<List<string>> UploadImageFile(MultipartFormDataContent content);
}

public class UploadImageService : IUploadImageService
{
    private readonly HttpClient _httpClient;

    public UploadImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> UploadImageFile(MultipartFormDataContent content)
    {
        var response = await _httpClient.PostAsync("Image/upload", content);

        return await response.Content.ReadFromJsonAsync<List<string>>();
    }
}