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

        public static async Task<List<string>> SaveMultiFile(List<IFormFile> images, string folder)
        {
            if (images != null && images.Count > 0)
            {
                var pathList = new List<string>();
                var dir = Path.Combine(@"wwwroot/img", folder);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                foreach (var image in images)
                {
                    var path = Path.Combine(dir, image.FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    pathList.Add(path.Replace("wwwroot", "").Replace('\\', '/'));
                }

                return pathList;
            }

            return null;
        }
    }
}
