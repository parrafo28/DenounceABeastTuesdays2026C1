using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DenounceBeastsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DenounceBeastsConnection")));

builder.Services.AddControllers();
 builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    // Registrar el perfil manualmente (opcional):
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly /* escanear automát. perfiles en el assembly */);

var automapperLicence = builder.Configuration.GetSection("KeysConfigurations:AutomapperLicenceKey").Value;
//var automapperLicence2 = builder.Configuration.GetSection("AutomapperLicenceKey").Value;
//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = automapperLicence, typeof(MappingProfile));


//builder.Services.AddAutoMapper(typeof(MappingProfile));

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
