using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using ProjetPokemon.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using ProjetPokemon.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetPokemon.Web
{
    public class Startup
    {



        static public ISourceDonneesPokemon SourceDonnees { get; } = new DonneesPokemonenMemoire();


        //const string connexionString = "Server=(localdb)\\mssqllocaldb;Database=ProjetPokemon;Trusted_Connection=true;";
        //private readonly PokemonDBContext db = ;

//        static public ISourceDonneesPokemon SourceDonnees { get; } = new DonneesPokemonSQL(new PokemonDBContext(connexionString));



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
