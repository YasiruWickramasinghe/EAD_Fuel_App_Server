using ASP.NET_Server.Models;
using ASP.NET_Server.Models.QueueModel;
using ASP.NET_Server.Models.StationModel;
using ASP.NET_Server.Models.StationStatus;
using ASP.NET_Server.Models.VehicleModel;
using ASP.NET_Server.Services;
using ASP.NET_Server.Services.QueueService;
using ASP.NET_Server.Services.StationService;
using ASP.NET_Server.Services.StationStatus;
using ASP.NET_Server.Services.VehicleService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add Student services to the container.
builder.Services.Configure<StudentStoreDatabaseSettinngs>(
        builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettinngs)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<StudentStoreDatabaseSettinngs>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(builder.Configuration.GetValue<string>("SudentStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStudentServvices, StudentService>();



// Add Station services to the container.
builder.Services.Configure<StationStoreDatabaseSettings>(
        builder.Configuration.GetSection(nameof(StationStoreDatabaseSettings)));

builder.Services.AddSingleton<IStationStoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<StationStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(builder.Configuration.GetValue<string>("StationStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStationServices, StationService>();



// Add Station services to the container.
builder.Services.Configure<StatusStoreDatabaseSettings>(
        builder.Configuration.GetSection(nameof(StatusStoreDatabaseSettings)));

builder.Services.AddSingleton<IStatusStoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<StatusStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(builder.Configuration.GetValue<string>("StationStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStatusService, StatusSevice>();


// Add Queue services to the container.
builder.Services.Configure<QueueStoreDatabaseSettings>(
        builder.Configuration.GetSection(nameof(QueueStoreDatabaseSettings)));

builder.Services.AddSingleton<IQueueStoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<QueueStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(builder.Configuration.GetValue<string>("QueueStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IQueueServices, QueueService>();

// Add Vehicle services to the container.
builder.Services.Configure<VehicleStoreDatabaseSettings>(
        builder.Configuration.GetSection(nameof(VehicleStoreDatabaseSettings)));

builder.Services.AddSingleton<IVehicleStoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<VehicleStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
        new MongoClient(builder.Configuration.GetValue<string>("VehicleStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IVehicleServices, VehicleService>();

// Other Services

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
