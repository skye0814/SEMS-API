﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240426111303_TeamLogo")]
    partial class TeamLogo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.29");

            modelBuilder.Entity("Core.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationUserGuid")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("TeamId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                            AccessFailedCount = 0,
                            Address = "",
                            ConcurrencyStamp = "9f9a6e55-33d2-46d7-b0bf-f88a05197828",
                            EmailConfirmed = false,
                            FirstName = "Administrator",
                            LastName = "Administrator",
                            LockoutEnabled = false,
                            MiddleName = "Administrator",
                            Phone = "",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "48a8e59d-932f-4df8-8112-5800db93e098",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SportId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Core.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("MatchStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MatchStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Team1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Team2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamId1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamId2")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Core.Entities.MatchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team1Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team2Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("MatchResults");
                });

            modelBuilder.Entity("Core.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("HeightInCm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("WeightInKg")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Core.Entities.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Basketball"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tennis"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Volleyball"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chess"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Swimming"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Badminton"
                        });
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamLogoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TeamLogoId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Core.Entities.TeamLogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TeamLogos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "/images/team icons/beaver.png",
                            Name = "Beaver"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "/images/team icons/bee.png",
                            Name = "Bee"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "/images/team icons/boar.png",
                            Name = "Boar"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "/images/team icons/buffalo.png",
                            Name = "Buffalo"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "/images/team icons/cat.png",
                            Name = "Cat"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "/images/team icons/chameleon.png",
                            Name = "Chameleon"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "/images/team icons/chicken.png",
                            Name = "Chicken"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "/images/team icons/clown-fish.png",
                            Name = "Clownfish"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "/images/team icons/crab.png",
                            Name = "Crab"
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = "/images/team icons/crocodile.png",
                            Name = "Crocodile"
                        },
                        new
                        {
                            Id = 11,
                            ImageUrl = "/images/team icons/dog.png",
                            Name = "Dog"
                        },
                        new
                        {
                            Id = 12,
                            ImageUrl = "/images/team icons/elephant.png",
                            Name = "Elephant"
                        },
                        new
                        {
                            Id = 13,
                            ImageUrl = "/images/team icons/frog.png",
                            Name = "Frog"
                        },
                        new
                        {
                            Id = 14,
                            ImageUrl = "/images/team icons/giraffe.png",
                            Name = "Giraffe"
                        },
                        new
                        {
                            Id = 15,
                            ImageUrl = "/images/team icons/gorilla.png",
                            Name = "Gorilla"
                        },
                        new
                        {
                            Id = 16,
                            ImageUrl = "/images/team icons/horse.png",
                            Name = "Horse"
                        },
                        new
                        {
                            Id = 17,
                            ImageUrl = "/images/team icons/lama.png",
                            Name = "Llama"
                        },
                        new
                        {
                            Id = 18,
                            ImageUrl = "/images/team icons/lion.png",
                            Name = "Lion"
                        },
                        new
                        {
                            Id = 19,
                            ImageUrl = "/images/team icons/mouse.png",
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = 20,
                            ImageUrl = "/images/team icons/owl.png",
                            Name = "Owl"
                        },
                        new
                        {
                            Id = 21,
                            ImageUrl = "/images/team icons/panda.png",
                            Name = "Panda"
                        },
                        new
                        {
                            Id = 22,
                            ImageUrl = "/images/team icons/parrot.png",
                            Name = "Parrot"
                        },
                        new
                        {
                            Id = 23,
                            ImageUrl = "/images/team icons/penguin.png",
                            Name = "Penguin"
                        },
                        new
                        {
                            Id = 24,
                            ImageUrl = "/images/team icons/pig.png",
                            Name = "Pig"
                        },
                        new
                        {
                            Id = 25,
                            ImageUrl = "/images/team icons/rhino.png",
                            Name = "Rhino"
                        },
                        new
                        {
                            Id = 26,
                            ImageUrl = "/images/team icons/sheep.png",
                            Name = "Sheep"
                        },
                        new
                        {
                            Id = 27,
                            ImageUrl = "/images/team icons/snake.png",
                            Name = "Snake"
                        },
                        new
                        {
                            Id = 28,
                            ImageUrl = "/images/team icons/turtle.png",
                            Name = "Turtle"
                        },
                        new
                        {
                            Id = 29,
                            ImageUrl = "/images/team icons/walrus.png",
                            Name = "Walrus"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                            ConcurrencyStamp = "964d638b-ef47-4f8c-96ec-cdd2b96e0cc9",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                            ConcurrencyStamp = "9c836476-2e90-40c3-92ed-8e3fab053d60",
                            Name = "Coach",
                            NormalizedName = "COACH"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");

                    b.HasData(
                        new
                        {
                            Id = "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05f17d5e-8a47-41c8-b3bd-9c347c74eafd",
                            Email = "semsapplication@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SEMSAPPLICATION@GMAIL.COM",
                            NormalizedUserName = "ADMINISTRATOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEDNxfCAGcrS+zXW2LIMZlFgxdU5d9krP7haqVnw2am9T/lnTg/upcxsE6bjuq9Tfiw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "615df557-3564-4d34-b39f-1400ae6c7fd5",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                            RoleId = "6ed57acf-cb38-4df4-ac5f-be45115fd783"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Core.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.HasOne("Core.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Core.Entities.Match", b =>
                {
                    b.HasOne("Core.Entities.Event", "Event")
                        .WithMany("Matches")
                        .HasForeignKey("EventId");

                    b.HasOne("Core.Entities.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id");

                    b.HasOne("Core.Entities.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id");

                    b.Navigation("Event");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("Core.Entities.MatchResult", b =>
                {
                    b.HasOne("Core.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Core.Entities.Participant", b =>
                {
                    b.HasOne("Core.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.HasOne("Core.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Core.Entities.TeamLogo", "TeamLogo")
                        .WithMany()
                        .HasForeignKey("TeamLogoId");

                    b.Navigation("Event");

                    b.Navigation("TeamLogo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}