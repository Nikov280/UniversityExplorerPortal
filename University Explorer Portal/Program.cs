using University_Explorer_Portal.Components;
using UniversityExplorerPortal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient and custom API services
builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<UniversityService>();
builder.Services.AddScoped<StudentApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
    

app.Run();