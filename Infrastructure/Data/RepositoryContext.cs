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
        DbSet<TeamLogo> TeamLogos { get; set; }

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

            modelBuilder.Entity<TeamLogo>().HasData(
                new TeamLogo { Id = 1, ImageUrl = "/images/team icons/beaver.png", Name = "Beaver" },
                new TeamLogo { Id = 2, ImageUrl = "/images/team icons/bee.png", Name = "Bee" },
                new TeamLogo { Id = 3, ImageUrl = "/images/team icons/boar.png", Name = "Boar" },
                new TeamLogo { Id = 4, ImageUrl = "/images/team icons/buffalo.png", Name = "Buffalo" },
                new TeamLogo { Id = 5, ImageUrl = "/images/team icons/cat.png", Name = "Cat" },
                new TeamLogo { Id = 6, ImageUrl = "/images/team icons/chameleon.png", Name = "Chameleon" },
                new TeamLogo { Id = 7, ImageUrl = "/images/team icons/chicken.png", Name = "Chicken" },
                new TeamLogo { Id = 8, ImageUrl = "/images/team icons/clown-fish.png", Name = "Clownfish" },
                new TeamLogo { Id = 9, ImageUrl = "/images/team icons/crab.png", Name = "Crab" },
                new TeamLogo { Id = 10, ImageUrl = "/images/team icons/crocodile.png", Name = "Crocodile" },
                new TeamLogo { Id = 11, ImageUrl = "/images/team icons/dog.png", Name = "Dog" },
                new TeamLogo { Id = 12, ImageUrl = "/images/team icons/elephant.png", Name = "Elephant" },
                new TeamLogo { Id = 13, ImageUrl = "/images/team icons/frog.png", Name = "Frog" },
                new TeamLogo { Id = 14, ImageUrl = "/images/team icons/giraffe.png", Name = "Giraffe" },
                new TeamLogo { Id = 15, ImageUrl = "/images/team icons/gorilla.png", Name = "Gorilla" },
                new TeamLogo { Id = 16, ImageUrl = "/images/team icons/horse.png", Name = "Horse" },
                new TeamLogo { Id = 17, ImageUrl = "/images/team icons/lama.png", Name = "Llama" },
                new TeamLogo { Id = 18, ImageUrl = "/images/team icons/lion.png", Name = "Lion" },
                new TeamLogo { Id = 19, ImageUrl = "/images/team icons/mouse.png", Name = "Mouse" },
                new TeamLogo { Id = 20, ImageUrl = "/images/team icons/owl.png", Name = "Owl" },
                new TeamLogo { Id = 21, ImageUrl = "/images/team icons/panda.png", Name = "Panda" },
                new TeamLogo { Id = 22, ImageUrl = "/images/team icons/parrot.png", Name = "Parrot" },
                new TeamLogo { Id = 23, ImageUrl = "/images/team icons/penguin.png", Name = "Penguin" },
                new TeamLogo { Id = 24, ImageUrl = "/images/team icons/pig.png", Name = "Pig" },
                new TeamLogo { Id = 25, ImageUrl = "/images/team icons/rhino.png", Name = "Rhino" },
                new TeamLogo { Id = 26, ImageUrl = "/images/team icons/sheep.png", Name = "Sheep" },
                new TeamLogo { Id = 27, ImageUrl = "/images/team icons/snake.png", Name = "Snake" },
                new TeamLogo { Id = 28, ImageUrl = "/images/team icons/turtle.png", Name = "Turtle" },
                new TeamLogo { Id = 29, ImageUrl = "/images/team icons/walrus.png", Name = "Walrus" }
            );
        }
    }
}
