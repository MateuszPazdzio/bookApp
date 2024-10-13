using Bogus;
using bookApp;
using bookApp.Models;
using bookApp.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookPositionRepository,BookPositionRepository>();
builder.Services.AddDbContext<BookAppContext>(cfg=>
    cfg.UseSqlServer(@"Server=DESKTOP-15VL6MS\SQLEXPRESS;Database=bookApp;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddValidatorsFromAssemblyContaining<BookPositionValidator>()
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(" / Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}














app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
