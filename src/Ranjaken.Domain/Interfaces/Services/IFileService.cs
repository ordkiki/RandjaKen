using Microsoft.AspNetCore.Http;
using Ranjaken.Domain.ValuesObject;

namespace Ranjaken.Domain.Interfaces.Services
{
    public interface IFileService
    {
        Task<Resource> UploadAsync(IFormFile? file, string folder);
        //Task<Resource> GetOneAsync();
    }
}
