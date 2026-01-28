var builder = WebApplication.CreateBuilder(args);

//TODO: Delete this
var LicenceKey =  "YOUR_LICENCE_KEY_HERE";
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
