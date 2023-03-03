using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using UserManagementCore.AutoMapper;
using UserManagementCore.BAL.Interfaces;
using UserManagementCore.BAL.Services;
using UserManagementCore.DAL.Interface;
using UserManagementCore.DAL.Repository;
using UserManagementCore.Filters;
using UserManagementCore.Models;


namespace UserManagementCore
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            //JWT barier token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            .UseLazyLoadingProxies(false));
            services.AddCors(); //add by me

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                          .AddEntityFrameworkStores<ApplicationDbContext>()
                          .AddDefaultTokenProviders();


            //add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
            //services.AddControllersWithViews()
            //               .AddNewtonsoftJson(options =>
            //                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //                );

            //Add Mapping
            services.AddAutoMapper(typeof(AutoMapperConfig));

            //add global exception filter upon controller
            services.AddControllers(options=> {
                options.Filters.Add(typeof(MyExceptionFilters));
            });
            /* [Caching]*/
            services.AddResponseCaching();

            /*
             Transient objects are always different; a new instance is provided to every controller and every service.
             Scoped objects are the same within a request, but different across different requests.
             Singleton objects are the same for every object and every request.
              Controller:
                Transient : Obj1 is generated
                Scoped : Obj1 is generated
                Singleton: Obj1 is generated
              Services:
                Transient : Obj2 is generated
                Scoped : Obj1 is generated
                Singleton: Obj1 is generated
            So for same http request Transient will create new object both controller ,services and others but scoped remain same, singleton are same untill project alive.
             */
            //services.AddTransient<IRepository<ApplicationRoleDetails>, RepositoryRoleDetails>();
            services.AddScoped<IRepository<ApplicationRoleDetails>, RepositoryRoleDetails>();
            services.AddScoped<ApplicationRoleDetailsService, ApplicationRoleDetailsService>();
            services.AddScoped<UserManagementService, UserManagementService>();
            services.AddScoped<IApplicationRoleService, ApplicationRoleService>();
            services.AddTransient<MyActionFilters>();
            //services.AddSingleton<IRepository,InmemoryRepository>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {

            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            /* [Caching]*/
            app.UseResponseCaching();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            ////must add when bearer token is apply
            app.UseAuthentication(); 
            app.UseAuthorization();
            //

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //seed dbContext ,single db context for whole application
            EF_Model.Initialize_DbContext_in_Startup(app.ApplicationServices);
            // this will do the initial DB population
            InitializeDatabaseAutoMigration(app);
        }


        /// <summary>
        /// Database auto migration
        /// </summary>
        /// <param name="app"></param>
        private void InitializeDatabaseAutoMigration(IApplicationBuilder app)
        {
            try
            {
                EF_Model.dbContext.Database.Migrate();
                //using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                //{
                //    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

                //    //if multiple db context
                //    //scope.ServiceProvider.GetRequiredService<ApplicationDbContext2>().Database.Migrate();

                //}
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //var logger = services.GetRequiredService<ILogger<Program>>();
                //logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
