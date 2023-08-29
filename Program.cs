using Flurl;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SkillsBackend.Client;
using SkillsDatabase;
using SkillsFrontEnd.Data;
using System.Net;
using System.Net.Http;


namespace SkillsFrontEnd;

public class Program
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
    public static SkillsDbContextFactory dbContextFactory { get; private set; } //TODO: Refactor static variable into WebApplication service
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

    private static void debug()
    {
        var context = dbContextFactory.CreateDbContext();
        var deleted = context.InvisibleEmployees.Where(e => e.LastName == "Mustermann14");
        if (deleted.Any())
            context.UnhideEmployee(deleted.First(), true);
        else
        {
            Console.WriteLine("No deleted employee Mustermann14 in database found");
        }
        context.Dispose();
    }

    public static void Main(string[] args)
    {
        var client = new ClientTest();
        client.GetEmployeesAsync();
        
        var builder = WebApplication.CreateBuilder(args);

        dbContextFactory = new SkillsDbContextFactory();

        debug();

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

        var x = Console.ReadKey();
        Console.WriteLine(x.Key.ToString());
    }
}

internal class ClientTest
{
    private SkillsClient CreateClient()
    {
        
        var client = new SkillsClient("http://localhost:63357/", "Integration_Test");
        //var client = new SkillsClient("https://localhost:63356/", "Integrat");
        return client;
    }
    public async void GetEmployeesAsync()
    {

        Console.WriteLine("Begin of Client Integration Test");
        var _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:63356/") };
        try
        {
            using var res = await _httpClient.GetAsync(_httpClient.BaseAddress.AppendPathSegment("Employees/1"));
            // The following line will throw HttpRequestException with StatusCode set if it wasn't 2xx.
            Console.WriteLine(res == null);
            res.EnsureSuccessStatusCode();
            Console.Write(res?.Content.ToString());
        }
        catch (Exception ex)
        {
            // Handle 404
            Console.WriteLine("Not found: " + ex.Message);
        }
        var client = CreateClient();
        // await client.Employees.PostAsync(new EmployeeDTin("August", "Test2500", "25.08.2023"));
        Console.WriteLine("CreateClient.GetEmployeesAsync Test");
        //var employees = await client.GetEmployeesAsync();
        //Console.WriteLine("employees.count = " + employees.Count);
        //foreach(var employee in employees) { await Console.Out.WriteLineAsync(employee.ToString()); }
        //var emp = await client.Employees.GetAsync(1);
        var emp = await client.GetEmployeeAsync(1);
        //Console.WriteLine(employee == null);
        await Console.Out.WriteLineAsync(emp?.ToString());
        var proficiencies = await client.GetProficiencyAsync(1);
        foreach (var prof in proficiencies) { await Console.Out.WriteLineAsync(prof.ToString()); }
        Console.WriteLine("End of Client Integration Test");
    }
}