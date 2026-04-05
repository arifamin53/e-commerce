using E_Commerce.Application.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Api.Middleware.Requestresponse
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestReultMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestReultMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var originalResponseStream = httpContext.Response.Body;
            var memoryStream=new MemoryStream();    
            httpContext.Response.Body = memoryStream;
            await _next(httpContext);
            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseText=await new StreamReader(memoryStream).ReadToEndAsync();

            if (IsJson.IsString(responseText))
            {
                httpContext.Response.Body = originalResponseStream;
                var responseObject = JsonSerializer.Deserialize<ResultResponse>(responseText, new JsonSerializerOptions(){
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase,    
                    PropertyNameCaseInsensitive=true
                });

                if(responseObject?.Value is not null)
                {
                    httpContext.Response.StatusCode = responseObject.StatusCode;

                }
                else if(responseObject?.ProblemDetails?.Status is  not null)
                {
                    httpContext.Response.StatusCode = responseObject.ProblemDetails.Status.Value;
                }
                await httpContext.Response.WriteAsync(responseText);
            }
            else
            {
                memoryStream.Seek(0, SeekOrigin.Begin); 
                await memoryStream.CopyToAsync(originalResponseStream);
                httpContext.Response.StatusCode = 500;
                httpContext.Response.Body = originalResponseStream; 
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestReultMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestReultMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestReultMiddleware>();
        }
    }
    public class ResultResponse 
    {
        public object? Value { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public ProblemDetails ProblemDetails { get; set; }
        public bool IsSuccess => ProblemDetails is null;
    }

}
