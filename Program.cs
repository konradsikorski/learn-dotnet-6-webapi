using Catalog.Repositories;
using Catalog.Settings;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String)); // treat Guid type in entities as string
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String));

// Add services to the container.
builder.Services.AddSingleton<IMongoClient>(serviceProvider => {
    var settings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Catalog", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
