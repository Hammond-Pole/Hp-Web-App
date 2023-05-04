// Create an instance of the web application builder.
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
var builder = WebApplication.CreateBuilder(args);




// Call the extension method, instantiate the service installers and configure services with dependency injection.
builder.Services
    .InstallServices(
        builder.Configuration,
typeof(IServiceInstaller).Assembly);

// Create an instance of the app.
var app = builder.Build();

// Add configuration.
app.ConfigureMiddleware();

// Start the App.
app.Run();