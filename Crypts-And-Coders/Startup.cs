using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Crypts_And_Coders.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.Services;

namespace Crypts_And_Coders
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddControllers(options =>
            //{
            //    options.Filters.Add(new AuthorizeFilter());
            //});

            services.AddControllers();

            services.AddDbContext<CryptsDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // TODO: AddIdentity
            // TODO: AddAuthentication
            // TODO: AddJwtBearer
            // TODO: Add authorization policies

            services.AddTransient<IEnemy, EnemyRepository>();
            services.AddTransient<ILocation, LocationsRepository>();
            services.AddTransient<IItem, ItemRepository>();
            services.AddTransient<ICharacter, CharacterRepository>();
            services.AddTransient<IStat, StatRepository>();
            services.AddTransient<ICharacterStat, CharacterStatRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            // TODO: serviceProvider.GetRequiredService<>();
            // TODO: Role initializer

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}