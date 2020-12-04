using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloAspWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // This method is for (1) configuring middleware before plugging it in
            //   (2) adding services to the Dependency Injection container
            services.AddControllers();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //    app.Use(async (context, next) =>
            //    {
            //        try
            //        {
            //            await next();
            //        }
            //        catch (Exception e)
            //        {
            //            await context.Response.WriteAsync(e.ToString());
            //        }
            //    });
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}"
                       );
                //endpoints.MapGet("/localFile", async (context) =>
                //{
                //    string fp = "/Users/danielgrant/Desktop/danielg-code/HelloAspWebApp/HelloAspWebApp/PracticePath.html";
                //    string htmlFile = System.IO.File.ReadAllText(fp);
                //    await context.Response.WriteAsync(htmlFile);
                //});
                //ASP.NET Core MVC is when we use a specific subset of middlewares/classes/practices
                //     within ASP.NET Core as a whole
                // Give it a name so you can refer to it
                endpoints.MapControllerRoute(
                    name: "hello-controller",
                    pattern: "hello",
                    defaults: new { controller = "Hello", action = "Action1" });
                //every route definition need to specify: 1) a controller 2) an action method on that controller
                // If the pattern isnt enough to do that, we need to set defaults.
                //     Do this with C# syntax called anonomyus type which creates an objecct without a class


                // Using parameters in the url for use somewhere in doc
                endpoints.MapControllerRoute(
                   name: "hello-controller2",
                   pattern: "hello/{param1}/{param2}",
                   defaults: new { controller = "Hello", action = "ParameterizedAction" });

                // route parameters can be constrained like with: ":int". if the given value doesnt match
                //   the route as a whole will not match
                //   Add a question mark to make the parameter optional and the route will still match if no value is provided
                //  can also add "=something" to provide a different deafult

                // a given request is matched against each of these route patterns in turn until the first one that
                //   match is found.
               


                endpoints.MapControllerRoute(
                   name: "hello-controller-generic",
                   pattern: "hi/{action=Action1}/{param1?}/{param2:int?}",
                   defaults: new { controller = "Hello"});
                // a route parameter named action is looked at to decide which action method is called in the first place

                //this route could match any controller and any action -"hello" and "action1" are just the defaults
                endpoints.MapControllerRoute(
                   name: "controller-generic",
                   pattern: "{controller=hello}/{action=Action1}/{param1?}/{param2:int?}");
            });



            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.ContentType = "text/html";
                  
                    await context.Response.WriteAsync("<!DOCTYPE <htm> <head></head> <body> Hello to World! </body> </html>");

                }
            });




            app.Run(async context =>
            {
                HttpRequest request = context.Request;

                HttpResponse response = context.Response;

                response.ContentType = "text/html";

                await response.WriteAsync("<!DOCTYPE <htm> <head></head> <body> Hello World! </body> </html>");
            });
        }
    }
}
