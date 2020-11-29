using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BoligKø.ApplicationService;
using BoligKø.ApplicationService.Mapper;
using BoligKø.Domain.DomainService;
using BoligKø.Domain.Model;
using BoligKø.Infrastructure.Commands;
using BoligKø.Infrastructure.context;
using BoligKø.Infrastructure.patterns;
using BoligKø.Infrastructure.Queries;
using BoligKø.Infrastructure.Queries.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BoligKø.Api
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
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddDbContext<BoligKøContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<AnsøgerCommand>();
            services.AddScoped<AnsøgerQuery>();

            //Dependency Injection
            services.AddScoped<IAnsøgerQuery, AnsøgerQuery>();
            services.AddScoped<ApplicationService.IAnsøgerCommand, AnsøgerCommand>();
            services.AddScoped<IAnsøgningCommand, AnsøgningCommand>();
            services.AddScoped<IAnsøgningQuery, AnsøgningQuery>();
            services.AddScoped<IAnsøgerAnsøgningDomainService, AnsøgerAnsøgningDomainService>();

            //Automapper
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new AutomapperProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Midlertidig
            services.AddScoped<IAnsøgerApplicationService, AnsøgerApplicationService>();
            services.AddScoped<IAnsøgningApplicationService, AnsøgningApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
