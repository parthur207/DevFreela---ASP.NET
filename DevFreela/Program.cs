

using DevFreela.Models;
using DevFreela.Services.Projects;
using Microsoft.AspNetCore.Builder;

namespace DevFreela
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<FreeLancerTotalCostConfig> (
                builder.Configuration.GetSection("FreeLancerTotalCost")
            );

            builder.Services.AddSingleton<IProjects,ProjectService>();

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
