
namespace Ranjaken.Domain.Exceptions
{
    public class ApiException(string message, int code, bool success) : Exception(message)
    {
        public int Code { get; set; } = code;
        public bool Success { get; set; } = success;
    }
}
