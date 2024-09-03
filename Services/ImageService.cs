using lab1.interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace lab1.services;

public class ImageService : IBufferedFileUploadService
{
    // Variables
    private string _uploadFolder = "UploadedFiles/";
    private string _fileName;
    private string _path;
    
    // Constructors
    public ImageService() {
        _fileName = "";
        _path ="";
    }

    public async Task<bool> UploadFile(IFormFile file)
    {
        try
        {
            if (file.Length > 0)
            {
                this._path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, this._uploadFolder));
                if (!Directory.Exists(this._path))
                {
                    Directory.CreateDirectory(this._path);
                }
                using (var fileStream = new FileStream(Path.Combine(this._path, this._fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }

    public async Task<(bool check, string filePath)> UploadAsync(IFormFile file, int id) {
        string formatFile = file.FileName.Split('.')[1];
        this._fileName = $"avt_{id}.{formatFile}";

        this._uploadFolder += $"{id}/";

        if (await this.UploadFile(file)) {
            return (true, Path.Combine(this._path, _fileName));
        } else {
            return (false, "");
        }
    }

    public async Task<byte[]> ToByteAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("File is null or empty", nameof(file));
        }

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
 }
