using ASP.NET_Server.Models;
using ASP.NET_Server.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<StudentStoreDatabaseSettinngs>(
        builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettinngs)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<StudentStoreDatabaseSettinngs>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(builder.Configuration.GetValue<string>("SudentStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStudentServvices, StudentService>();

IMvcBuilder mvcBuilder = builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
