using System.Data;
using Microsoft.Data.SqlClient;
using TaskManager.Repositories.Interfaces;

namespace TaskManager.Repositories;

public sealed class FileProvider : IFileProvider
{
    private readonly string _connectionString;

    public FileProvider(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }
    
    public async Task<(Stream FileStream, string FileName, string ContentType)?> GetFileAsync(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT FileName, ContentType, FileData FROM Files WHERE ID = @Id",  conn);
        cmd.Parameters.AddWithValue("@Id", id);

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess);

        if (await reader.ReadAsync())
        {
            var fileName = reader.GetString(0);
            var contentType = reader.GetString(1);
            
            const int bufferSize = 8192;
            var memoryStream = new MemoryStream();

            using (var stream = reader.GetStream(2))
            {
                await stream.CopyToAsync(memoryStream, bufferSize);
            }

            memoryStream.Position = 0;
            return (memoryStream, fileName, contentType);
        }

        return null;
    }
}