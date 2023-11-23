using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

var portArgument = Array.Find(args, arg => arg.StartsWith("--port="));
if (portArgument != null)
{
    var portValue = portArgument.Split('=')[1];
    if (int.TryParse(portValue, out var port))
    {
        builder.Configuration["Application:ListeningPort"] = port.ToString();
    }
}

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
