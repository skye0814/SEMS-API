using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public RepositoryContext(DbContextOptions options) : base(options) 
        {
        }

        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Sport> Sports { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<MatchResult> MatchResults { get; set; }
        DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser
            {
                Id = "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = "semsapplication@gmail.com",
                NormalizedEmail = "SEMSAPPLICATION@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "FnZBechj")
            };
            modelBuilder.Entity<IdentityUser>().HasData(user);


            // Comment this whenever the migration fails, it means it already exist in the db and
            // the seeder is trying again to add these values : Matt
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "6ed57acf-cb38-4df4-ac5f-be45115fd783", Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Id = "38b13138-2eb6-415b-b1d4-c36f6c6fdee4", Name = "Coach", NormalizedName = "COACH" }
            );

            // Set created user to an admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = "6ed57acf-cb38-4df4-ac5f-be45115fd783" // Admin Role
                }
            );

            // Personal details for the administrator seed
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = user.Id,
                FirstName = "Administrator",
                MiddleName = "Administrator",
                LastName = "Administrator"
            });

            modelBuilder.Entity<Sport>().HasData(
                new Sport { Id = 1, Name = "Basketball" },
                new Sport { Id = 2, Name = "Tennis" },
                new Sport { Id = 3, Name = "Volleyball" },
                new Sport { Id = 4, Name = "Chess" },
                new Sport { Id = 5, Name = "Swimming" },
                new Sport { Id = 6, Name = "Badminton" }
            );
        }
    }
}
