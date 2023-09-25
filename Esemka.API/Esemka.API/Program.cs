using Esemka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EsemkaSchool.API",
        Description = "Backend API untuk aplikasi mobile EsemkaSchool. \n\n " +
                      "Untuk Path icon Extracurricular bisa akses link: http://url:5000/images/{NamaIcon}. Contoh:  <a href=\"http://localhost:5000/images/sepak_bola.png\"> http://localhost:5000/images/sepak_bola.png </a> \n\n " +
                      "Untuk URL API di mobile bisa pakai <a href=\"http://10.0.2.2:5000\"> http://10.0.2.2:5000 </a> (pakai ini karena url menggunakan localhost)",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<EsemkaContext>(options => options.UseInMemoryDatabase("EsemkaDB"));

var app = builder.Build();

Seeder.Seed(app);

app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
