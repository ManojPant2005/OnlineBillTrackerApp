using BlazorServerBillTracker.Data;
using BlazorServerBillTracker.Data.DatabaseConfiguration;
using BlazorServerBillTracker.Data.Service;
using BlazorServerBillTracker.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Error connecting to database"));
});
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey: "Ngo9BigBOggjHTQxAR8/V1NGaF1cXGNCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWH5cdHRSRWheWUN2Vkc=");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
