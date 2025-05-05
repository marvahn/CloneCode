using CloneCode.Database;
using CloneCode.Setting;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("", policy => { policy.WithOrigins("*"); });
});
builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

builder.Services.AddDbContext<DatabaseContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (ctx, next) =>
{
    var headers = ctx.Response.Headers;

    headers.Append("X-Frame-Options", "DENY");
    headers.Append("X-XSS-Protection", "1; mode=block");
    headers.Append("X-Content-Type-Options", "nosniff");
    headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");

    await next();
});

app.Run();
