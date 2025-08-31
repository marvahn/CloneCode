using CloneCode.Application.Interface;
using CloneCode.Infrastructure.Extension;
using CloneCode.Infrastructure.Middleware.JwtAuthentication;
using CloneCode.Infrastructure.Models;
using CloneCode.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Supabase;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt();
builder.Services.AddCors(options =>
{
    options.AddPolicy("", policy => { policy.WithOrigins("*"); });
});
builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

// appsettings.json의 "SupabaseSettings" 섹션을 DI 컨테이너에 추가
builder.Services.Configure<SupabaseSettings>(
    builder.Configuration.GetSection("SupabaseSettings")
);

// Supabase 클라이언트를 DI 컨테이너에 등록
builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<SupabaseSettings>>().Value;
    var supabase = new Client(settings.Url, settings.ApiKey);
    supabase.InitializeAsync().Wait();
    return supabase;
});

builder.Services.AddSingleton<ISupabaseService, SupabaseService>();
builder.Services.AddSingleton<ITokenService, JwtTokenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloneCode API V1");
//    }
//);



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (ctx, next) =>
//{
//    var headers = ctx.Response.Headers;

//    headers.Append("X-Frame-Options", "DENY");
//    headers.Append("X-XSS-Protection", "1; mode=block");
//    headers.Append("X-Content-Type-Options", "nosniff");
//    headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");

//    await next();
//});

app.Run();
