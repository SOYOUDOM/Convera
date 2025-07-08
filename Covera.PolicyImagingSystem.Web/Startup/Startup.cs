using Abp.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Covera.PolicyImagingSystem.Web.Startup
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAbp<IMRWebHostModule>(); // <--- Make sure this line exists!
            services.AddSwaggerGen();                // 3. Register Swagger
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAbp(); // This MUST come after AddAbp and before anything else.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}