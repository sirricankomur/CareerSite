using CareerSite.Business.Abstract;
using CareerSite.Business.Concrete;
using CareerSite.Core.Abstract;
using CareerSite.Core.Concrete.EfCore;
using CareerSite.MvcWebUI.EmailServices;
using CareerSite.MvcWebUI.Identity;
using CareerSite.MvcWebUI.Resources.Views;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CareerSite.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _configuration;
        private const string trCulture = "tr";
        private const string enCulture = "en";
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=CareerSite;Integrated Security=True"));
            services.AddDbContext<CareerContext>(options => options.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=CareerSite;Integrated Security=True"));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IRecordService, RecordManager>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
                 new SmtpEmailSender(
                     _configuration["EmailSender:Host"],
                     _configuration.GetValue<int>("EmailSender:Port"),
                     _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                     _configuration["EmailSender:UserName"],
                     _configuration["EmailSender:Password"])
                );

            services.AddControllersWithViews();

            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(opt => opt.DataAnnotationLocalizerProvider = (type, factory) =>
              {
                  var assemblyName = new AssemblyName(typeof(SharedModelResource).GetTypeInfo().Assembly.FullName);
                  return factory.Create(nameof(SharedModelResource), assemblyName.Name);

              });



            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo(trCulture),
                    new CultureInfo(enCulture)
                };

                opt.DefaultRequestCulture = new RequestCulture(trCulture);
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;

                opt.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };

                opt.RequestCultureProviders = new[] {new RouteDataRequestCultureProvider()
                {
                    Options = opt
                } };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICartService cartService)
        {
            app.UseStaticFiles(); // wwwroot

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "allcourses",
                  pattern: "courses",
                  defaults: new { controller = "Home", action = "Index" }
              );

                endpoints.MapControllerRoute(
                  name: "home",
                  pattern: "courses",
                  defaults: new { controller = "Home", action = "Index" }
              );

                endpoints.MapControllerRoute(
                  name: "records",
                  pattern: "records",
                  defaults: new { controller = "Cart", action = "GetRecords" }
              );


                endpoints.MapControllerRoute(
                  name: "checkout",
                  pattern: "checkout",
                  defaults: new { controller = "Cart", action = "Checkout" }
              );

                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart",
                    defaults: new { controller = "Cart", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "dashboard",
                    pattern: "dashboard",
                    defaults: new { controller = "Admin", action = "Dashboard" }
                );

                endpoints.MapControllerRoute(
                   name: "adminuseredit",
                   pattern: "admin/user/{id?}",
                   defaults: new { controller = "Admin", action = "UserEdit" }
               );

                endpoints.MapControllerRoute(
                   name: "adminusers",
                   pattern: "admin/user/list",
                   defaults: new { controller = "Admin", action = "UserList" }
               );

                endpoints.MapControllerRoute(
                    name: "adminroles",
                    pattern: "admin/role/list",
                    defaults: new { controller = "Admin", action = "RoleList" }
                );

                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/role/create",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
                );


                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "admin/role/{id?}",
                    defaults: new { controller = "Admin", action = "RoleEdit" }
                );

                endpoints.MapControllerRoute(
                    name: "admincourses",
                    pattern: "admin/courses",
                    defaults: new { controller = "Admin", action = "CourseList" }
                );

                endpoints.MapControllerRoute(
                    name: "admincoursecreate",
                    pattern: "admin/courses/create",
                    defaults: new { controller = "Admin", action = "CourseCreate" }
                );

                endpoints.MapControllerRoute(
                    name: "admincourseedit",
                    pattern: "admin/courses/{id?}",
                    defaults: new { controller = "Admin", action = "CourseEdit" }
                );

                endpoints.MapControllerRoute(
                   name: "admincategories",
                   pattern: "admin/categories",
                   defaults: new { controller = "Admin", action = "CategoryList" }
               );

                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categories/create",
                    defaults: new { controller = "Admin", action = "CategoryCreate" }
                );

                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "CategoryEdit" }
                );


                // localhost/search    
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "search" }
                );

                endpoints.MapControllerRoute(
                    name: "coursedetails",
                    pattern: "{url}",
                    defaults: new { controller = "Shop", action = "details" }
                );

                endpoints.MapControllerRoute(
                    name: "courses",
                    pattern: "{culture?}/courses/{category?}",
                    defaults: new { controller = "Shop", action = "list" }
                );

                endpoints.MapControllerRoute(
                    name: "homesite",
                    pattern: "",
                    defaults: new { controller = "Home", action = "Index" }
                );
                //endpoints.MapControllerRoute(
                //    name: "en",
                //   pattern: "{culture=en}/{controller=Home}/{action=Index}/{id?}"
                //);
                endpoints.MapControllerRoute(
                    name: "tr",
                    pattern: "tr",
                    defaults: new { controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{culture?}/{controller=Home}/{action=Index}/{id?}"
               );

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}"
                //);


            });

            SeedIdentity.Seed(userManager, roleManager, cartService, configuration).Wait();
        }
    }
}
