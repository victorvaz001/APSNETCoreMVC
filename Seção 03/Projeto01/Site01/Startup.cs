using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Site01.Database;

namespace Site01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//configuração MVC 
            services.AddDbContext<DatabaseContext>(options=> {
                //Providers - Bibliotecas conexões com Banco de dados, MySQL, Oracle, SQLServer, PostgreSQL, FireBird, Db2..
                //options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=site01;Integrated Security=True");
                options.UseSqlite("Data source=Database\\site01.db");
            });

            services.AddDistributedMemoryCache(); //armazenar dados em memoria
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /**
            * www.site.com.br/cliente/lista(Página com listagem clientes)
            * wwww.site.com.br/cliente/deletar/30
            * wwww.site.com.br/cliente/visualizar/30
            * wwww.site.com.br/noticia/visualizar/acidente-de-carro-nas-rodovias
            * {dominio}/{Controller=Home}/{Acction=Index}/{id?}
            */

            app.UseSession();
            app.UseStaticFiles(); //acesar arquivos estaticos no wwwwrot
            app.UseMvcWithDefaultRoute(); //configuração (rota-uri ou url)MVC    

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            }); 
            */
        }
    }
}
