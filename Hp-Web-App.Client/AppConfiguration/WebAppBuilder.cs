using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

namespace Hp_Web_App.Client.AppConfiguration;

public static class WebAppBuilder
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {

            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();


        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        app.UseCors();

        return app;
    }
}
