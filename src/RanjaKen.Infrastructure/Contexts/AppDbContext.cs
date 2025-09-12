using Microsoft.EntityFrameworkCore;
using Ranjaken.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanjaKen.Infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Team
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(team => team.Name).IsRequired(false);
                entity.Property(team => team.Status).IsRequired(false);

                entity.OwnsOne(team => team.Logo, profil =>
                {
                    profil.Property(logo => logo.Url).IsRequired(false);
                    profil.Property(logo => logo.Extension).IsRequired(false);
                    profil.Property(logo => logo.ContentType).IsRequired(false);
                    profil.Property(logo => logo.Name).IsRequired(false);
                });

            });
            #endregion

            #region Player
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(p => p.FirstName).IsRequired(false);
                entity.Property(p => p.LastName).IsRequired(false);
                entity.Property(p => p.Pseudo).IsRequired(false);
                entity.Property(p => p.BirthDate).IsRequired(false);
                entity.Property(p => p.Size).IsRequired(false);
                entity.Property(p => p.CreatedAt).IsRequired(false);
                entity.Property(p => p.UpdatedAt).IsRequired(false);
                entity.Property(p => p.TeamId).IsRequired(false);

                entity.OwnsOne(c => c.Avatar, profil =>
                {
                    profil.Property(p => p.Url).IsRequired(false);
                    profil.Property(p => p.Extension).IsRequired(false);
                    profil.Property(p => p.ContentType).IsRequired(false);
                    profil.Property(p => p.Name).IsRequired(false);
                });

                entity.HasOne(c => c.Team)
                    .WithMany()
                    .HasForeignKey(c => c.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region Team
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(team => team.EmailAdress).IsRequired(false);
                entity.Property(team => team.Password).IsRequired(false);
            });
            #endregion

        }
    };
    
}