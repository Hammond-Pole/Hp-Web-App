using Hp_Web_App.Shared.AppServices.Graph;
using Hp_Web_App.Shared.ClientFactories;
using Hp_Web_App.Shared.Functions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Logging;

//var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//IConfiguration config = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile($"appsettings.json", true, true)
//.Build();

var builder = WebApplication.CreateBuilder(args);

// Add environment variables to the ConfigurationBuilder
builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
builder.Services.AddControllers();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IHelperFunctions, HelperFunctions>();
builder.Services.AddScoped<IGraphService, GraphService>();
builder.Services.AddTransient<IGraphClientFactory, GraphClientFactory>();

builder.Services.AddDbContext<DbWebAppContext>(options =>
        options.UseSqlServer(connectionString));

var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddHttpClient("graph", client =>
{
    client.BaseAddress = new Uri("https://graph.microsoft.com/v1.0/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("User-Agent", "hp-document-portal");
});



//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme);
//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy
//    options.FallbackPolicy = options.DefaultPolicy;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();