using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using League.Data.Sql;
using League.Data.Sql.Interface;

namespace LeagueHttpApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddScoped<ILeagueSqlSession, LeagueSqlSession>(CreateSqlConnection);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private LeagueSqlSession CreateSqlConnection(IServiceProvider provider)
        {
            var connectionString = Configuration.GetValue<string>("ConnectionStrings:Sql");

            return new LeagueSqlSession(connectionString);
        }

        #endregion
    }
}
