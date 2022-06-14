using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace gptemplate.Utlis.Extensions
{
    public static class FileExtension
    {
        public static string RootPath = "";
        public static string SaveFile(this IFormFile file,string folders, string fileName = "")
        {
            if (fileName == "")
            {
                fileName = Guid.NewGuid().ToString() + file.FileName;
            }
            using (FileStream fs = new FileStream(Path.Combine(RootPath, folders, fileName),FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return fileName;
        }
        public static void DeleteFile(string path)
        {
            if (File.Exists(Path.Combine(RootPath,path)))
            {
                File.Delete(Path.Combine(RootPath, path));
            }
        }
    }
}
