using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Helper
{
    public class Utils
    {
        public static async Task<string> SaveFile(IFormFile image, string path)
        {
            if (image != null && image.Length > 0)
            {
                var folder = Path.Combine(@"wwwroot/img", path);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                path = Path.Combine(folder, image.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return path.Replace("wwwroot", "").Replace('\\', '/');
            }

            return null;
        }
    }
}
