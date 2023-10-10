using Dal;
using Google.Api;
using LogicaNegocios;
using Microsoft.Extensions.Configuration;
using RandomColors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Entities.Models.RandomColorsStoreDatabaseSettings>(builder.Configuration.GetSection("RandomColorsStoreDatabase"));
builder.Services.AddSingleton<InteractionRepository>();

// Add services to the container.
// builder.Services.Configure<RandomColors.RandomColorsStoreDatabaseSettings>(builder.Configuration.GetSection("RandomColorsStoreDatabase"));
builder.Services.AddScoped<InteractionService>();


/*
 builder.Services.AddScoped<InteractionRepository>();
builder.Services.AddSingleton(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return configuration.GetConnectionString("RandomColorsStoreDatabase:ConnectionString");
});

 */
// builder.Services.AddScoped<InteractionRepository>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configu  re the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
