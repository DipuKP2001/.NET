using Microsoft.AspNetCore.Mvc;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers;

[ApiController]
[Route("file")]
public sealed class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    
    public FileController(IFileService fileService)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _fileService.GetFileAsync(id);

        if (result == null)
        {
            return NotFound("File not found");
        }
        
        var (stream, fileName, contentType) = result.Value;
        
        return new FileStreamResult(stream, contentType)
        {
            FileDownloadName = fileName
        };
    }
}