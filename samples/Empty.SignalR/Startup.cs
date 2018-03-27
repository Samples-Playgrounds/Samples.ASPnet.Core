using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Empty.SignalR
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //------------------------------------------------------------------
            #region    SignalR
            services.AddSignalR();
            #endregion SignalR
            //------------------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //------------------------------------------------------------------
            #region    SignalR
            // UseSignalR must be called before UseMvc
            app.UseSignalR
            (
                routes =>
                {
                    // "http://${document.location.host}/{hubname}"
                    string hubname = "chat";
                    routes.MapHub<APISignalR.HubChat>(hubname);
                }
            );
            #endregion SignalR
            //------------------------------------------------------------------

            //------------------------------------------------------------------
            #region    Static Files
            DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("startup.html");

            app
                //  searches wwwroot/ 
                //  for:
                //      index.htm[l]
                //      default.htm[l]
                .UseDefaultFiles()
                //  serve static files
                .UseStaticFiles()
                ;
            #endregion Static Files
            //------------------------------------------------------------------


            app.Run
                (
                    async (context) =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    }
                );
        }
    }
}
