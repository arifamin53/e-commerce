using Carter;
using E_Commerce.Api.Middleware.Requestresponse;

namespace E_Commerce.Api.Middleware.PublicMiddleware
{
    public static class RequestResponsePipeline
    {
        public static WebApplication UseCommonmiddleWare(this WebApplication app)
        {


            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}
           
            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.MapCarter();

            app.UseRequestReultMiddleware();
            app.Run();
            return app; 
        }
    }
}
