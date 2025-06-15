using DevFreela.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectEntity> Projects { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserProjectEntity> UserProjects { get; set; }

        public DbSet<SkillEntity> Skills { get; set; }

        public DbSet<UserSkillEntity> UserSkills { get; set; }

        public DbSet<ProjectCommentEntity> ProjectComments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // ProjectEntity
            builder.Entity<ProjectEntity>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasOne(x => x.FreeLancer)
                    .WithMany(x => x.FreeLancerProjects)
                    .HasForeignKey(x => x.IdFreeLancer)
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasMany(x => x.Comments)
                    .WithOne(x => x.Project)
                    .HasForeignKey(x => x.IdProject)
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasMany(x => x.Purchases) // ou "UserProjects", se for o nome da prop
                    .WithOne(x => x.Project)
                    .HasForeignKey(x => x.IdProject)
                    .OnDelete(DeleteBehavior.Cascade);
            });


            // UserEntity
            builder.Entity<UserEntity>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasMany(x => x.Skills)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasMany(x => x.Purchases); // ou "UserProjects", se for o nome da prop

            });
        }
    }
}