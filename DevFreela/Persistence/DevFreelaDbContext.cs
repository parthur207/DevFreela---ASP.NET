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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Skill>(x => x.HasKey(x => x.Id));
            builder.Entity<UserSkill>(x=>x.HasKey(x=>x.))

            base.OnModelCreating(modelBuilder);
        }
    }
}
