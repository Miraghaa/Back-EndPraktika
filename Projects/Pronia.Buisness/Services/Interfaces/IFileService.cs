using Microsoft.AspNetCore.Http;

namespace Pronia.Buisness.Services.Interfaces;
public interface IFileService
{
    Task<string> UploadFile(IFormFile file, string root,int kb, params string[] folders);
    void RemoveFile(string root,string filePath);
        
}

