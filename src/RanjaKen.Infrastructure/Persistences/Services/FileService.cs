using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Ranjaken.Domain.Interfaces.Services;
using Ranjaken.Domain.ValuesObject;

namespace RanjaKen.Infrastructure.Persistences.Services
{
    public class FileService(IConfiguration configuration) : IFileService
    {
        public Task<bool> DeleteAsync(IFormFile? file, string path)
        {
            
            return null;
        }

        public async Task<Resource> UploadAsync(IFormFile file, string folder)
        {
            if (file == null || file == null || file.Length == 0)
                throw new Exception("No file found");
            string? basePath = configuration.GetSection("FileStorage:BasePath").Value;

            if (string.IsNullOrWhiteSpace(basePath))
                throw new Exception("No destination path found in configuration");

            string directory = Path.Combine(basePath, folder);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string extension = Path.GetExtension(file.FileName);
            string contentType = file.ContentType;
            string filename = Guid.NewGuid().ToString("N") + extension;
            string fullPath = Path.Combine(directory, filename);

            using (FileStream stream = new (fullPath, FileMode.Create))
                await file.CopyToAsync(stream);

            return new Resource(
                Name: filename,
                Url: Path.Combine("/", folder, filename).Replace("\\", "/"),
                ContentType: contentType,
                Extension: extension, 
                size: 4*4* 1024
            );
        }
    }
}
