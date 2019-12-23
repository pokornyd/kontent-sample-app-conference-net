using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using kontent_sample_app_conference_net.Resolvers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kontent_sample_app_conference_net
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
            services
                .AddDeliveryInlineContentItemsResolver<Tweet, TweetResolver>()
                .AddSingleton<ITypeProvider,CustomTypeProvider>()
                .AddDeliveryClient(Configuration)
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Error/Status");
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "agenda-item",
                    template: "{location}/Agenda/{urlSlug}",
                    defaults: new { controller = "Agenda", action = "Detail" }
                );
                routes.MapRoute(
                    name: "speaker",
                    template: "{location}/Speakers/{id}",
                    defaults: new { controller = "Speakers", action = "Detail" }
                );

                routes.MapRoute(
                    name: "home",
                    template: "{location}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "LandingPage", action = "Index" }
                );
            });
        }
    }
}
