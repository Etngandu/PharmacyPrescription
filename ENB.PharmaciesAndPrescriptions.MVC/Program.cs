using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.EF;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Configuration;
using ENB.PharmaciesAndPrescriptions.MVC;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.EF.Repositories;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<PharmaciesAndPrescriptionsContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("PharmacyCstrg")));
builder.Services.AddAutoMapper(typeof(PharmaciesAndPrescriptionsProfile));
 builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IAsyncCustomerRepository, AsyncCustomerRepository>();
builder.Services.AddScoped<IAsyncPhysicianRepository, AsyncPhysicianRepository>();
builder.Services.AddScoped<IAsyncDrugCompanyRepository, AsyncDrugCompanyRepository>();
builder.Services.AddScoped<IAsyncUnitOfWorkFactory, AsyncEFUnitOfWorkFactory>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "adrs",
    pattern: "{addresses}/{*address}",
    defaults: new {controller="Addresses", action="Edit"});

app.Run();
