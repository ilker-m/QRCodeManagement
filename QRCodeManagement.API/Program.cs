using QRCodeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using QRCodeManagement.Application.Services;
using QRCodeManagement.Infrastructure.Services;

using QRCodeManagement.Application.Services;
using QRCodeManagement.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IQRCodeService, QRCodeService>();

builder.Services.AddHttpClient<IErpService, MockErpService>();
builder.Services.AddScoped<IQRCodeService, QRCodeService>();

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
app.UseAuthorization();
app.MapControllers();
app.Run();
