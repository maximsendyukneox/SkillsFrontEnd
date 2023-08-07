using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SkillsDatabase;
using SkillsFrontEnd.Data;


namespace SkillsFrontEnd;

public class Program
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
    public static SkillsDbContextFactory dbContextFactory { get; private set; } //TODO: Refactor static variable into WebApplication service
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        dbContextFactory = new SkillsDbContextFactory();

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        //builder.Services.AddSingleton<WeatherForecastService>();
        

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
    }
}