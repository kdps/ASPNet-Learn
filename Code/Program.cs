using Example.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;

public class Program
{

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Example.Startup>();

    public async static Task Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<UserStore>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await ContextSeed.SeedRolesAsync(userManager, roleManager);
                await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        host.Run();
    }
}
