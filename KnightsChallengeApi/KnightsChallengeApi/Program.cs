using KnightsChallengeApi.Context;
using KnightsChallengeApi.Repository;
using KnightsChallengeApi.Repository.IRepository;
using KnightsChallengeApi.Service;
using KnightsChallengeApi.Service.IService;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("HeroStoreDatabase"));

builder.Services.AddTransient<IServiceKnight,ServiceKnight>();
builder.Services.AddTransient<IMongoRepository,MongoRepository>();


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		builder =>
		{
			builder.WithOrigins("http://localhost:5173", "")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials();
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
