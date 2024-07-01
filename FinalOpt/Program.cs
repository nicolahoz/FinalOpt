using FinalOpt;
using FinalOpt.Infraestructure.Interfaces;
using FinalOpt.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var configuration = builder.Configuration;
// Add services to the container.
IoC.AddService(builder.Services);
builder.Services.AddRazorPages();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ITablingService, TablingService>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
