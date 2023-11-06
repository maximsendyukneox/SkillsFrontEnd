using SkillsBackend.Client;
using MudBlazor.Services;

namespace SkillsFrontEnd;

public class Program
{
    private static SkillsClient? client = null;
    public static SkillsClient Client { get => client!; }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var isAzureRelease = !builder.Environment.IsDevelopment();
        var API_BASE_URI = isAzureRelease ? Constants.API_BASE_URI_AZURE : Constants.API_BASE_URI_local_https;
        client = new SkillsClient(API_BASE_URI, "Integration_Test");

        // Add services to the container.
        builder.Services.AddMudServices();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
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

internal class ClientTest
{
    public async void GetEmployeesAsync()
    {
        Console.WriteLine("Begin of Client Integration Test");
        var client = new SkillsClient(Constants.API_BASE_URI_local_https, "Integration_Test");
        Console.WriteLine("CreateClient.GetEmployeesAsync Test");
        var emp = await client.GetEmployeeAsync(1);
        await Console.Out.WriteLineAsync(emp?.ToString());
        var proficiencies = await client.GetProficiencyAsync(1);
        foreach (var prof in proficiencies) { await Console.Out.WriteLineAsync(prof.ToString()); }
        Console.WriteLine("End of Client Integration Test");
    }
}