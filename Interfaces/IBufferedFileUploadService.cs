namespace lab1.interfaces;
public interface IBufferedFileUploadService
{
    Task<bool> UploadFile(IFormFile file);
}