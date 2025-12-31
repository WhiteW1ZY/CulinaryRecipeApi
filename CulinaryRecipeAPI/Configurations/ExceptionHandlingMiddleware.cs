using CulinaryRecipeAPI.Infrastructure.Models;
using CulinaryRecipeAPI.UseCases.Exceptions;
using System.Net;
using System.Text.Json;

namespace CulinaryRecipeAPI.Configurations
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;  
        public ExceptionHandlingMiddleware(
           RequestDelegate next)
        {
            _next = next;  
        } 
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            { 
                await HandleExceptionAsync(context, ex);
            }
        } 
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var errorReponse = new ApiErrorResponse
            {
                Instance = context.Request.Path,
                Title = "An error occurred while processing your request",
                Detail = exception.Message
            };

            switch (exception)
            {
                case NotFoundException _:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorReponse.Status = StatusCodes.Status404NotFound;
                    errorReponse.Title = "Not found error"; 
                break;

                case ValidationException _:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorReponse.Status = StatusCodes.Status400BadRequest;
                    errorReponse.Title = "Validation error"; 
                break;
                case AlreadyExistExeption _:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorReponse.Status = StatusCodes.Status400BadRequest;
                    errorReponse.Title = "Already exist error"; 
                break; 
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorReponse.Status = StatusCodes.Status500InternalServerError;
                    errorReponse.Title = "Internal server error";
                    errorReponse.Detail = "An internal server error has occurred";
                break;
            }

            var json = JsonSerializer.Serialize(errorReponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}  
