using System.Net;
using FluentFTP;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace Sughd.Auto.Admin.Services;

public interface IUploadImageService
{
    Task<string> UploadImageFile(IBrowserFile file);
}

public class UploadImageService : IUploadImageService
{
    public async Task<string> UploadImageFile(IBrowserFile browserFile)
    {
        var maxAllowedSize = 2 * 1024 * 1024;
        var formContent = new MultipartFormDataContent();
        var fileContent = new StreamContent(browserFile.OpenReadStream(maxAllowedSize));
        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(browserFile.ContentType);

        formContent.Add(fileContent, "file", browserFile.Name);

        var file = (IFormFile)formContent;
        
        if (file == null || file.Length == 0)
            return "No file uploaded.";

        var fileName = Path.GetFileName(file.FileName);
        var filePath = Path.GetTempFileName();

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        // Now upload to FTP
        bool result = await UploadFileToFtp(filePath, fileName);
        if (result)
        {
            System.IO.File.Delete(filePath); // Clean up the temp file
            return "File uploaded successfully.";
        }
        else
        {
            return "Failed to upload file.";
        }
    }
    
    private async Task<bool> UploadFileToFtp(string filePath, string fileName)
    {
        var ftpClient = new FtpClient("win6081.site4now.net");
        ftpClient.Credentials = new NetworkCredential("shabonsharipov", "987094321_SH");

        try
        {
            ftpClient.Connect();
            ftpClient.UploadFile(filePath, "/" + fileName);
            ftpClient.Disconnect();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}