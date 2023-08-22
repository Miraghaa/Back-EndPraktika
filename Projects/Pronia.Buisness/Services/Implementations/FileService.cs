using Microsoft.AspNetCore.Http;
using Pronia.Buisness.Exceptions;
using Pronia.Buisness.Services.Interfaces;
using Pronia.Buisness.Utilities;
using Pronia.Core.Entities;

namespace Pronia.Buisness.Services.Implementations;

public class FileService : IFileService
{
    public void RemoveFile(string root, string filePath)
    {
        string fileroot = Path.Combine(root,filePath);
        if (File.Exists(fileroot))
        {
            File.Delete(fileroot);
        }
    }

    public async Task<string> UploadFile(IFormFile file, string root, int kb,params string[] folders)
    {
        if (!file.CheckFileSize(kb))
        {
            throw new FileSizeException("agilli ol");
        }
        if (!file.CheckFileType("image"))
        {
            {
                throw new FileTypeException("ess bos seydi ureyivi sixma duzeler");  
            }
        }
        string folderRoot = string.Empty;
        foreach (var folder in folders)
        {
            folderRoot = Path.Combine(folderRoot, folder);
        }
        string filename = await file.UploadFile(root,folderRoot); 
        return filename;
    }
}
