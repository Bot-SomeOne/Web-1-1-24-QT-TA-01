using lab1.interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace lab1.services
{
    public class UploadAvatar
    {
        private readonly string _uploadFolder = "UploadedFiles";

        public UploadAvatar()
        {
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public async Task<bool> UploadAsync(IFormFile file, string id)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return false;
                }

                var fileName = $"{id}_avt{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(_uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}