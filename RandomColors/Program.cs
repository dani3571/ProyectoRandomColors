using Dal;
using Google.Api;
using LogicaNegocios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RandomColors.RandomColorsStoreDatabaseSettings>(builder.Configuration.GetSection("RandomColorsStoreDatabase"));
builder.Services.AddTransient<InteractionService>();
builder.Services.AddScoped<InteractionService>();
builder.Services.AddScoped<InteractionLN>();
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
