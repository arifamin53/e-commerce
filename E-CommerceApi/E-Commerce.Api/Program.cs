using E_Commerce.Api;
using E_Commerce.Api.Middleware.PublicMiddleware;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddOpenApi();
builder.Services.AddAPiServices(builder.Configuration,builder.Environment);
var app = builder.Build();

app.UseCommonmiddleWare();
