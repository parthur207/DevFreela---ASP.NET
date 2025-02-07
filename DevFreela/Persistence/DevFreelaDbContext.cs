using DevFreela.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        protected DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }


        //Configuração do relacionamento entre as entidades. Declaração de chaves primárias/estrangeiras
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Project>(x => {
                x.HasKey(x => x.Id);//chave primária
                x.HasOne(x => x.FreeLancer)//Um FreeLancer
                    .WithMany(x => x.FreeLancerProjects)// Possui muitos projetos
                    .HasForeignKey(x => x.IdFreeLancer)//chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict);//Restrição de deleção 

                x.HasOne(x => x.Client)//Um cliente 
                    .WithMany(x => x.OwnedProjects)//Pode adquirir muitos projetos
                    .HasForeignKey(x => x.IdClient)//Chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict);
        });

            builder.Entity<User>(x =>
            {
                x.HasKey(x => x.Id);//Chave primária
                x.HasMany(x => x.Skills)// Muitas habilidade
                    .WithOne(x => x.User)//Pertencem a um usuario
                    .HasForeignKey(x => x.IdUser)//Chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict);
                    
            });

            builder.Entity<Skill>(x => 
            { 
                x.HasKey(x => x.Id);
                
            });

            builder.Entity<UserSkill>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Skill)
                    .WithMany(x => x.UserSkills)
                    .HasForeignKey(x => x.IdSkill)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ProjectComment>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Project)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #region Implemento do uso do banco de dados em memoria para testes

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase()
        }

        #endregion

        #region Configuração do OnConfiguring para comunicação com o DB utilizando a string de conexão declarada no arquivo do json
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration= new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DevFreelaConnection");

            optionsBuilder.UseSqlServer(connectionString);

        }*/

        #endregion

    }
}