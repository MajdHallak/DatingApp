using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseCors(
    x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200")
    );

// ordering is important here.
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
Console.WriteLine("Development Mode: " + app.Environment.IsDevelopment());
app.Run();
