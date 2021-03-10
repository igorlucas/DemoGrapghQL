using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Infra.Contexts;
using Infra.GraphQL.Schemas;
using Infra.IRepositories;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Contracts.IRepositories;
using Web.Helper;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlite(Configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<CountrySchema>();
            services.AddGraphQL().AddSystemTextJson().AddGraphTypes(typeof(CountrySchema), ServiceLifetime.Scoped);


            services.AddCors();
            services.AddControllersWithViews();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyMethod();
                opt.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGraphQL<CountrySchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
