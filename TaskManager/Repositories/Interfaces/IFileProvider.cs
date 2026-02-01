namespace TaskManager.Repositories.Interfaces;

public interface IFileProvider
{
    Task<(Stream FileStream, string FileName, string ContentType)?> GetFileAsync(int id);
}