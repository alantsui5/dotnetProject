using Microsoft.EntityFrameworkCore;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//  1. Pages UI
builder.Services.AddRazorPages();

// 2. Database
builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
