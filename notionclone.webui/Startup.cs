using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using notionclone.data.Abstract;
using notionclone.data.Concrete.EfCore;
using notionclone.business.Abstract;
using notionclone.business.Concrete;
using notionclone.webui.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace notionclone.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer(@"Server=DESKTOP-87LVU45;Database=NotionDB;Trusted_Connection=true"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options=> {
                                                options.Password.RequireDigit=true;
                                                options.Password.RequiredLength=6;
                                                options.Password.RequireLowercase=true;
                                                options.Password.RequireUppercase=true;
                                                options.Password.RequireNonAlphanumeric=true;

                                                options.Lockout.MaxFailedAccessAttempts=5;
                                                options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(1);
                                                options.Lockout.AllowedForNewUsers=true;
                                                            // options.User.AllowedUserNameCharacters = "";
                                                options.User.RequireUniqueEmail=true;
                                                options.SignIn.RequireConfirmedEmail=false;
                                                options.SignIn.RequireConfirmedPhoneNumber=false;
                                                });

            services.ConfigureApplicationCookie(options=> {options.Cookie.Name="NotionClone";
                                                            options.ExpireTimeSpan=TimeSpan.FromMinutes(30);
                                                            options.LoginPath="/account/login";
                                                            options.LogoutPath="/account/logout";
                                                            options.AccessDeniedPath="/account/accessdenied";
                                                            options.SlidingExpiration=true;
                                                            options.Cookie = new CookieBuilder
                                                            {
                                                                HttpOnly = true,
                                                                Name = ".NotionClone.Security.Cookie",
                                                            };
            });


            services.AddScoped<ITemplateRepository, SQLTemplateRepository>();
            services.AddScoped<ITemplateService, TemplateManager>();
            
            services.AddScoped<IProductRepository, SQLProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); //wwwroot
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });
            if (env.IsDevelopment())
            {
                //SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "home/addtemplate/",
                    defaults: new { controller = "Home", action = "AddTemplate" }
                );

                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "product/edit/{id?}",
                    defaults: new { controller = "Product", action = "Edit" }
                );

                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "product/list/{id?}",
                    defaults: new { controller = "Product", action = "List" }
                );

                

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Product", action = "Search" }
                );
                

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Main}/{id?}"
                    );
            });
        }
    }
}
