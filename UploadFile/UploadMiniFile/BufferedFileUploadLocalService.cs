namespace myProject.UploadFile.UploadMiniFile;

public class BufferedFileUploadLocalService : IBufferedFileUploadService
{
    public async Task<string> UploadFile(IFormFile file)
    {
        string path = "";
        string time = "";
        var localtime = DateTimeOffset.Now.AddHours(7);
        time = localtime.Ticks.ToString();
        try
        {
            if (file.Length > 0)
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/Storage/Image"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string imageName = time + "_" + file.FileName;
                using (var fileStream = new FileStream(Path.Combine(path, imageName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                string newPath = "/Storage/Image/" + imageName;
                return newPath;
            }
            else
            {
                throw new Exception("No file");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }


    public Task<bool> DeleteFile(string image)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Storage/Image", image);
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("File path not found");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Delete file fail", e);
        }
    }

    public async Task<string> ViewFile(string image)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Storage/Image", image);
        try
        {
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                throw new Exception("File not found");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Views file fail", e);
        }
    }
}