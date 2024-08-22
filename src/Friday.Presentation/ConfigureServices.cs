using Microsoft.Extensions.Options;

namespace Friday.Presentation;

public static class ConfigureServices
{
    public static void Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

        app.UseRouting();
        app.MapControllers();
        app.MapHealthChecks("/api/health");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();
    }
}