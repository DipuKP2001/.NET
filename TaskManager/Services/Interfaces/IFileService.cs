namespace TaskManager.Services.Interfaces;

public interface IFileService
{
    Task<(Stream FileStream, string FileName, string ContentType)?> GetFileAsync(int id);
}