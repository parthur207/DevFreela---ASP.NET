using DevFreela.Models;
using DevFreela.Persistence;
using DevFreela.Services.Projects;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DevFreela.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<FreeLancerTotalCostConfig> (
                builder.Configuration.GetSection("FreeLancerTotalCost")
            );

            //Implemento de um banco de dados em memória (para testes)
            //builder.Services.AddDbContext<DevFreelaDbContext>(x => x.UseInMemoryDatabase("MyDbContextInMemory"));

            #region Configuração do banco de dados SQL Server


            builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevFreelaConnection")));
             

            #endregion

            //builder.Services.AddScoped<IConfigService, ConfigService>();

            builder.Services.AddScoped<IProjects,ProjectService>();

            // Adiciona serviços ao contêiner antes de Build()
            builder.Services.AddControllersWithViews();

            // Registra o Swagger
            builder.Services.AddSwaggerGen(); 

            var app = builder.Build();

            // Configura o middleware do pipeline de requisições
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela API v1");
                    c.RoutePrefix = string.Empty; // Acessa diretamente na raiz "/"
                });
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
