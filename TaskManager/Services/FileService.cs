using TaskManager.Repositories.Interfaces;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services;

public sealed class FileService : IFileService
{
    private readonly IFileProvider _fileProvider;
    
    public FileService(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }
    
    public async Task<(Stream FileStream, string FileName, string ContentType)?> GetFileAsync(int id)
    {
        return  await _fileProvider.GetFileAsync(id);
    }
}