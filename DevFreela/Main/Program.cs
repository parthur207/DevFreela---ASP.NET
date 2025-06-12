using DevFreela.Application.Interfaces;
using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.OpenApi.Models;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DevFreela.API.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            //Configuração do Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DevFreela API",
                    Version = "v1",
                    Description = "API - Plataforma de comercialização de soluções digitais.",
                    Contact = new OpenApiContact
                    {
                        Name = "Paulo Andrade",
                        Email = "parthur207@gmail.com"
                    }
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Informe o token JWT: Bearer {seu token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            //banco de dados InMemory
            builder.Services.AddDbContext<DevFreelaDbContext>(options =>
                options.UseInMemoryDatabase("DevFreelaDbContext"));

            //Banco de dados SQL
            /*var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Conexão: {cnn}");

            builder.Services.AddDbContext<DbContextInMemory>(options => options.UseSqlServer(cnn));*/


            builder.Services.AddScoped<IProjectInterface, ProjectService>();
            builder.Services.AddScoped<IGenericSkillInterface, SkillsService>();
            builder.Services.AddScoped<IUserSkillInterface, UserSkillService>();
            builder.Services.AddScoped<IAdminUserInterface, UserService>();

            builder.Services.AddTransient<IJwtInterface, JwtService>();

            //Autenticação JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            //Autorização
            builder.Services.AddAuthorization();

            var app = builder.Build();

            //pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela API v1");
                });
            }


            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

}
