using Microsoft.AspNetCore.Http;
using Pronia.Core.Entities;

namespace Pronia.Buisness.Utilities;
// metod yaradanda oxunaqli olmalidi yoxsa tupoy issiz qalassan 
public static class Extention
{
    // iformfile extensiyn olmasi ucun this yazirdiq 
    public static bool CheckFileSize(this IFormFile file, int kb)
    {
        return file.Length / 1024 <= kb;
    }
    public static bool CheckFileType(this IFormFile file,string filetype)
    {
        return file.ContentType.Contains(filetype);
    }
    public static async Task<string> UploadFile(this IFormFile file,
        string root,
        string folderRoot)
    {
        //asagidaki string olada biler belke olsa daha yaxsi olar heleki bize problem yaratmir diye comentde qalsin. combine verdiyimiz stringleri birlesdirir ve root  yaradir
        //guid 16 reqemli olur addar ferqliliyi ucun istifade olunur
        string name = Guid.NewGuid().ToString() + file.FileName;
        string filename = Path.Combine(folderRoot, name);
        string fileRoot = Path.Combine(root, filename);
        // using operatoru destorey edir open cloth eliyir meqsedi budu
        using (FileStream fileStream = new FileStream(fileRoot, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        return filename;
    }
}
