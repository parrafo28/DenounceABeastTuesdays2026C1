using DenounceBeasts.API.Models;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infrastructure.Repositories;
using DenounceBeasts.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DenounceBeastsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DenounceBeastsConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly);

//var automapperLicence = builder.Configuration.GetSection("KeysConfigurations:AutomapperLicenceKey").Value;
//builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = automapperLicence, typeof(MappingProfile));

builder.Services.AddTransient<MunicipalityRepository>();
builder.Services.AddTransient<SectorRepository>();
builder.Services.AddTransient<GenericRepository<Status>>();
builder.Services.AddTransient<UnitOfWork>();


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
