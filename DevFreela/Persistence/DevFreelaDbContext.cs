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

        public DbSet<User> Users{ get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }


        //Configuração do relacionamento entre as entidades. Declaração de chaves primárias
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Skill>(x => x.HasKey(x => x.Id));
            builder.Entity<UserSkill>(x=>x.HasKey(x=>x.))

            base.OnModelCreating(modelBuilder);
        }


        //Config comunicação ao db utilizando o conect string do appsettings.json
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DevFreelaDbContext);
            
    }
}
