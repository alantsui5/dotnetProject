using Microsoft.EntityFrameworkCore;
using ContosoPizza.Services;
using ContosoPizza.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

// 2. Controller
builder.Services.AddControllers();

// 2. Database
builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

builder.Services.AddSqlite<PromotionsContext>("Data Source=./Promotions/Promotions.db");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();
