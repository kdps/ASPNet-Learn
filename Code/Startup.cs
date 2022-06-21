using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;


namespace Example
{
    public class Startup
    {
        private static string _applicationPath = string.Empty;
        private static string _contentRootPath = string.Empty;

    }
    
    
        public IConfigurationRoot Configuration { get; set; }

        [Obsolete]
        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            _contentRootPath = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"./Environment/appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            // Database Context

            services.AddDbContext<ApplicationDbContext>(option => {
                var connetionString = Configuration.GetConnectionString("DefaultConnection");
                var driver = Configuration.GetConnectionString("ProviderName");

                if (driver == "Mysql")
                {
                    option.UseMySql(
                        connetionString,
                        ServerVersion.AutoDetect(connetionString)
                    );
                }
                else if (driver == "SqlServer")
                {
                    option.UseSqlServer(
                        connetionString
                    );
                }
            });

            // CORS

            services.AddCors();

            // Scope

            services.AddScoped<UserManager<UserStore>>();
            services.AddScoped<SignInManager<UserStore>>();

            // Identity

            services.AddIdentity<UserStore, UserRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Api

            // services.AddEndpointsApiExplorer();
            // Only use for minimal API

            // Context

            services.AddHttpContextAccessor();

            // Cache

            services.AddMemoryCache();

            // Authorization, Authentication

            services.AddAuthentication();
            services.AddAuthorization();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            // MVC

            services.AddMvc();

            services.AddMvcCore();

            services.AddControllers();

            services.AddControllersWithViews()
                    .AddSessionStateTempDataProvider();

            // Blazor

            services.AddServerSideBlazor();

            services.AddRazorPages()
                    .AddSessionStateTempDataProvider();

            // Session

            services.AddDistributedMemoryCache();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);

                options.Cookie.Name = "SessionStorage";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Environment

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }

            if (!env.IsDevelopment()) {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        {
                            context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                // error.Error.Message
                                await context.Response.WriteAsync("System Error").ConfigureAwait(false);
                            }
                        }
                    });
                });
            }

            // Middleware

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/");
                }
            });

            // CORS

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
             });

            // Force Redirect to Https

            app.UseHttpsRedirection();

            // Session

            app.UseSession();
            app.UseCookiePolicy();

            // Rendering

            app.UseStaticFiles();

            // Routing

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapBlazorHub();

                endpoints.MapDefaultControllerRoute().RequireAuthorization();

                endpoints.MapControllers();

                endpoints.MapRazorPages();
            });
        }
    }
}
