using System.Globalization;
using dotnet_site_project.Middlewares;
using dotnet_site_project.Resources;
using InvertedSoftware.PLogger.Core;
using dotnet_site_project.services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options => {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(LocalizationResource));
    });


builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("uk"),
    };
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var settings = new PLoggerSettings(builder.Configuration);
builder.Logging.ClearProviders();
builder.Logging.AddPLogger(settings);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<IFileService, FileService>();


var app = builder.Build();
app.UseRequestLocalization();

app.UseMiddleware<LogsMiddleware>();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "email",
    pattern: "{controller=Mail}/{action=Index}");

app.Run();