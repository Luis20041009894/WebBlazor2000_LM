using Blazor;
using Blazor.Interfaces;
using Blazor.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

Config cadena = new Config(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddSingleton(cadena);


builder.Services.AddScoped<ILoginServicio, LoginServicio>();
builder.Services.AddScoped<IUsusarioServicio, UsusarioServicio>();


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
