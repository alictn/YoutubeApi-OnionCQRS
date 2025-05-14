using YoutubeApi.Application;
using YoutubeApi.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;//Yukar�da se�ti�im production veya devolopment gibi isimleri burada al�yoruz
builder.Configuration
    .SetBasePath(env.ContentRootPath)//localde yada sunucuda generic olarak dosya yolumuzu al�yoruz 
    .AddJsonFile("appsettings.json", optional: false)//bu app settings dosyas�n� bulmas� i�in de�erimizi false vedik
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);//buras� olabilir de olmayabilir de

builder.Services.AddPersistence(builder.Configuration);//bu k�s�m bizim persistence katman�m�z� eklememizi sa�l�yor
builder.Services.AddAplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
