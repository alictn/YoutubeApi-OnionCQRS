using YoutubeApi.Application;
using YoutubeApi.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;//Yukarýda seçtiðim production veya devolopment gibi isimleri burada alýyoruz
builder.Configuration
    .SetBasePath(env.ContentRootPath)//localde yada sunucuda generic olarak dosya yolumuzu alýyoruz 
    .AddJsonFile("appsettings.json", optional: false)//bu app settings dosyasýný bulmasý için deðerimizi false vedik
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);//burasý olabilir de olmayabilir de

builder.Services.AddPersistence(builder.Configuration);//bu kýsým bizim persistence katmanýmýzý eklememizi saðlýyor
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
