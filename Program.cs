using SkillsBackend.Client;
using MudBlazor.Services;

namespace SkillsFrontEnd;

public class Program
{
    public static SkillsClient Client { get; private set; } = new SkillsClient(Constants.API_BASE_URI, "Integration_Test");

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
      

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
    private SkillsClient CreateClient()
    {
        var client = new SkillsClient(Constants.API_BASE_URI, "Integration_Test");
        return client;
    }
    public async void GetEmployeesAsync()
    {
        Console.WriteLine("Begin of Client Integration Test");
        var client = CreateClient();
        Console.WriteLine("CreateClient.GetEmployeesAsync Test");
        var emp = await client.GetEmployeeAsync(1);
        await Console.Out.WriteLineAsync(emp?.ToString());
        var proficiencies = await client.GetProficiencyAsync(1);
        foreach (var prof in proficiencies) { await Console.Out.WriteLineAsync(prof.ToString()); }
        Console.WriteLine("End of Client Integration Test");
    }
}