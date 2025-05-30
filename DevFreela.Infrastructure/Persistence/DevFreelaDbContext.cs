﻿using DevFreela.Domain.Entities;
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

        public DbSet<SkillEntity> Skills { get; set; }

        public DbSet<UserSkillEntity> UserSkills { get; set; }

        public DbSet<ProjectCommentEntity> ProjectComments { get; set; }


        //Configuração do relacionamento entre as entidades. Declaração de chaves primárias/estrangeiras
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ProjectEntity>(x =>
            {
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

            builder.Entity<UserEntity>(x =>
            {
                x.HasKey(x => x.Id);//Chave primária

                x.HasMany(x => x.Skills)// Muitas habilidades
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.IdUser)//Chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<SkillEntity>(x =>
            {
                x.HasKey(x => x.Id);

            });

            builder.Entity<UserSkillEntity>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Skill)
                    .WithMany(x => x.UserSkills)
                    .HasForeignKey(x => x.IdSkill)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ProjectCommentEntity>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Project)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}