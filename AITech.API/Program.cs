using AITech.Business.Extensions;
using AITech.DataAccess.Context;
using AITech.DataAccess.Extensions;
using AITech.DataAccess.Interceptors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Mevcut servisler
builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();

// HttpClient ekleyin (AI Assistant için gerekli)
builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    options.AddInterceptors(new AuditDbContextInterceptor());
});

// CORS ekleyin (WebUI ile iletiþim için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebUI", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7172",
            "http://localhost:5043",
            "https://localhost:7149"  // API'nin kendi URL'si
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS'u kullan (Authorization'dan ÖNCE!)
app.UseCors("AllowWebUI");

app.UseAuthorization();
app.MapControllers();

app.Run();