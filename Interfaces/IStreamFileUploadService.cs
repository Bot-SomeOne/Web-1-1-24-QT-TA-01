using Microsoft.AspNetCore.WebUtilities;

namespace lab1.interfaces;

public interface IStreamFileUploadService
{
    Task<bool> UploadFile(MultipartReader reader, MultipartSection section);
}