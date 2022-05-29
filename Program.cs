using System;
using Microsoft.EntityFrameworkCore;
using moneylandingApp.Data;
using moneylandingApp.Structure;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISuperAdmin, SuperAdminRepository>();
builder.Services.AddScoped<ILandingMoney, LandingMoneyRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt => 
opt.UseNpgsql(builder.Configuration.GetConnectionString("moneylanding")));

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

app.Run();
