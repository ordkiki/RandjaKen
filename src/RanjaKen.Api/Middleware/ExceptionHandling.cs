using Ranjaken.Domain.Exceptions;
using RanjaKen.Api.Model;
using System.ComponentModel.DataAnnotations;

namespace RanjaKen.Api.Middleware
{
    public class ExceptionHandling(RequestDelegate _next, ILogger<ExceptionHandling> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

         
            catch (ExistingPlayerException ex)
            {
                string date = DateTime.UtcNow.ToString("dd//MM//yyyy hh:mm:ss");
                _logger.LogError($"Date : {date} email is already used by another employee : {ex.Message}");
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message, ex.Success);
            }
            
            catch (ApiException ex)
            {
                string date = DateTime.UtcNow.ToString("dd//MM//yyyy hh:mm:ss");

                _logger.LogError($"Date : {date} ApiValidation  gere : {ex.Message}");

                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message, ex.Success);
            }

            catch (ArgumentException ex)
            {
                string date = DateTime.UtcNow.ToString("dd//MM//yyyy hh:mm:ss");
                _logger.LogError($"Date : {date} Argumenation exception gere : {ex.Message}");
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message, false);

            }

            
            catch (Exception ex)
            {
                string date = DateTime.UtcNow.ToString("dd//MM//yyyy hh:mm:ss");
                _logger.LogError($" : {ex.Message}");
                _logger.LogError($"Date : {date} exception non gerer : {ex}");
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        private static async Task WriteResponseAsync(HttpContext context, int statusCode, string message, object? data = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            ApiResponse<object> response = new()
            {
                Success = false,
                Code = statusCode,
                Message = message,
            };
            if (data != null)
                response.Data = data;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
