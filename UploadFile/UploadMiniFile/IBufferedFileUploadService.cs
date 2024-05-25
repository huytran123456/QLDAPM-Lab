namespace myProject.UploadFile.UploadMiniFile;

public interface IBufferedFileUploadService
{
    Task<string> UploadFile(IFormFile file);
    
    Task<bool> DeleteFile(string image);
    Task<string> ViewFile(string image);
}