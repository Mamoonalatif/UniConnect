using UniConnect.Services;
using UniConnect.Components;
using UniConnect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Components.Authorization;
using UniConnect.Components.Account;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

// DB context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity setup
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


// App services
builder.Services.AddScoped<TestimonialService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<LostFoundService>();

// Identity-related Blazor services
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();

// Email sender (no-op)
builder.Services.AddScoped<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();
builder.Services.AddHttpContextAccessor();

// Razor components with server interactivity
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


builder.Services.Configure<CircuitOptions>(options =>
{
    options.DetailedErrors = true;
});

var app = builder.Build();
ChatBotBridge.Configure(app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>());

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapRazorPages();
app.MapAdditionalIdentityEndpoints();
app.MapControllers();

app.Run();
