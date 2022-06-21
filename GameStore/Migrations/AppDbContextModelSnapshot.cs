﻿// <auto-generated />
using System;
using GameStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStore.Domain.Entities.AllGames", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Developersid")
                        .HasColumnType("int");

                    b.Property<int>("Ganresid")
                        .HasColumnType("int");

                    b.Property<int>("Platformsid")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAddedSite")
                        .HasColumnType("datetime2");

                    b.Property<string>("descriptionG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameGame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("Developersid");

                    b.HasIndex("Ganresid");

                    b.HasIndex("Platformsid");

                    b.ToTable("AllGames");

                    b.HasData(
                        new
                        {
                            id = 401,
                            Developersid = 201,
                            Ganresid = 101,
                            Platformsid = 301,
                            Poster = "2077.png",
                            amount = 29,
                            dateAddedSite = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descriptionG = " Cyberpunk 2077 — компьютерная игра в жанре экшен в открытом мире, разработанная и изданная польской студией CD Projekt. Действие игры происходит в 2077 году в Найт-Сити, вымышленном североамериканском городе из вселенной Cyberpunk.",
                            nameGame = "Cyberpunk 2077",
                            price = 34,
                            releaseDate = new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 402,
                            Developersid = 201,
                            Ganresid = 101,
                            Platformsid = 301,
                            Poster = "GTA5.png",
                            amount = 10,
                            dateAddedSite = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descriptionG = "GTA V — компьютерная игра в жанре action-adventure с открытым миром, разработанная компанией Rockstar North и изданная компанией Rockstar Games.",
                            nameGame = "Grand Theft Auto V",
                            price = 25,
                            releaseDate = new DateTime(2013, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 403,
                            Developersid = 201,
                            Ganresid = 101,
                            Platformsid = 301,
                            Poster = "Valheim.png",
                            amount = 4,
                            dateAddedSite = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descriptionG = "Valheim — компьютерная игра в жанре симулятора выживания в открытом мире, разрабатываемая шведской компанией Iron Gate и изданная компанией Coffee Stain.",
                            nameGame = "Valheim",
                            price = 10,
                            releaseDate = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 404,
                            Developersid = 201,
                            Ganresid = 101,
                            Platformsid = 301,
                            Poster = "Assassin1.png",
                            amount = 22,
                            dateAddedSite = new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descriptionG = "Действие игры разворачивается во времена Третьего крестового похода, а именно в 1191 году. В настоящем времени бармена Дезмонда Майлса, главного героя, похищает корпорация «Абстерго», которая с помощью Анимуса, машины для извлечения генетической памяти, хочет найти артефакт Первой Цивилизации. В курс дела Дезмонда вводят учёный Уоррен Видик и его ассистентка Люси Стиллман. Они рассказывают ему, что он является потомком ассасина Альтаира ибн-Ла-Ахада, который обнаружил артефакт, и через него хотят узнать местонахождение артефакта.",
                            nameGame = "Assassin’s Creed",
                            price = 13,
                            releaseDate = new DateTime(2007, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Basket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllGamesid")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("finalPrice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AllGamesid");

                    b.HasIndex("UserId");

                    b.ToTable("Basket");

                    b.HasData(
                        new
                        {
                            id = 801,
                            AllGamesid = 401,
                            UserId = "702",
                            amount = 1,
                            finalPrice = 3
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Developers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nameDeveloper")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            id = 201,
                            nameDeveloper = "Bethesda"
                        },
                        new
                        {
                            id = 202,
                            nameDeveloper = "Blizzard"
                        },
                        new
                        {
                            id = 203,
                            nameDeveloper = "Valve"
                        },
                        new
                        {
                            id = 204,
                            nameDeveloper = "Electronic Arts"
                        },
                        new
                        {
                            id = 205,
                            nameDeveloper = "RockStar Games"
                        },
                        new
                        {
                            id = 206,
                            nameDeveloper = "Ubisoft"
                        },
                        new
                        {
                            id = 207,
                            nameDeveloper = "Square Enix"
                        },
                        new
                        {
                            id = 208,
                            nameDeveloper = "Activision"
                        },
                        new
                        {
                            id = 209,
                            nameDeveloper = "Konami"
                        },
                        new
                        {
                            id = 210,
                            nameDeveloper = "2K Games"
                        },
                        new
                        {
                            id = 211,
                            nameDeveloper = "Matrix Games"
                        },
                        new
                        {
                            id = 212,
                            nameDeveloper = "Nacon"
                        },
                        new
                        {
                            id = 213,
                            nameDeveloper = "Majesco"
                        },
                        new
                        {
                            id = 214,
                            nameDeveloper = "CD Projekt Red"
                        },
                        new
                        {
                            id = 215,
                            nameDeveloper = "Iron Gate AB"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.GameKey", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllGamesid")
                        .HasColumnType("int");

                    b.Property<string>("Key_game")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AllGamesid");

                    b.ToTable("GameKey");

                    b.HasData(
                        new
                        {
                            id = 901,
                            AllGamesid = 401,
                            Key_game = "XXXX-XXXX-XXXX"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Ganres", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nameGanres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Ganres");

                    b.HasData(
                        new
                        {
                            id = 101,
                            nameGanres = "Экшн"
                        },
                        new
                        {
                            id = 102,
                            nameGanres = "Приключения"
                        },
                        new
                        {
                            id = 103,
                            nameGanres = "RPG"
                        },
                        new
                        {
                            id = 104,
                            nameGanres = "Симуляторы"
                        },
                        new
                        {
                            id = 105,
                            nameGanres = "Спорт"
                        },
                        new
                        {
                            id = 106,
                            nameGanres = "Гонки"
                        },
                        new
                        {
                            id = 107,
                            nameGanres = "Казуал"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Platforms", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("namePlatform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            id = 301,
                            namePlatform = "Steam"
                        },
                        new
                        {
                            id = 302,
                            namePlatform = "Origin"
                        },
                        new
                        {
                            id = 303,
                            namePlatform = "Battle.net"
                        },
                        new
                        {
                            id = 304,
                            namePlatform = "RockStar Launcher"
                        },
                        new
                        {
                            id = 305,
                            namePlatform = "Epic Games Launcher"
                        },
                        new
                        {
                            id = 306,
                            namePlatform = "Ubisoft Connect"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Shares", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllGamesid")
                        .HasColumnType("int");

                    b.Property<int>("discountPrice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AllGamesid");

                    b.ToTable("Shares");

                    b.HasData(
                        new
                        {
                            id = 501,
                            AllGamesid = 401,
                            discountPrice = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "601",
                            ConcurrencyStamp = "3532a74b-ef26-4b8c-acc8-304c109f499f",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "602",
                            ConcurrencyStamp = "9802e0d9-e5db-429e-8bd9-98a059ce0a67",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "701",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "14cfa550-4dc7-46f0-8b32-0d180849a77c",
                            Email = "deeLimpay@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "deeLimpay@mail.ru",
                            NormalizedUserName = "deeLimpay",
                            PasswordHash = "AQAAAAEAACcQAAAAEPi4XqNOKfQGZFRwqAwGSDfWtZ4YtPzqLAd2MjK+46dRgTQdB3AXNce8XQg2TJ28qQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "deeLimpay"
                        },
                        new
                        {
                            Id = "702",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0264894a-5637-4427-ab57-85f49bb31a55",
                            Email = "stepa@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "stepa@gmail.com",
                            NormalizedUserName = "Stepashka",
                            PasswordHash = "AQAAAAEAACcQAAAAEAEbCs0NYY8wUXoHJ/c9rs3cHA8lUjr8//AvoABZGSDGK0rRmggI09nsxdZAyE/UzA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Stepashka"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "701",
                            RoleId = "601"
                        },
                        new
                        {
                            UserId = "702",
                            RoleId = "602"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GameStore.Domain.Entities.AllGames", b =>
                {
                    b.HasOne("GameStore.Domain.Entities.Developers", "Developers")
                        .WithMany("AllGames")
                        .HasForeignKey("Developersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Domain.Entities.Ganres", "Ganres")
                        .WithMany("GanresAllGames")
                        .HasForeignKey("Ganresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Domain.Entities.Platforms", "Platforms")
                        .WithMany("AllGames")
                        .HasForeignKey("Platformsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Basket", b =>
                {
                    b.HasOne("GameStore.Domain.Entities.AllGames", "AllGames")
                        .WithMany("Basket")
                        .HasForeignKey("AllGamesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GameStore.Domain.Entities.GameKey", b =>
                {
                    b.HasOne("GameStore.Domain.Entities.AllGames", "AllGames")
                        .WithMany("GameKeys")
                        .HasForeignKey("AllGamesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameStore.Domain.Entities.Shares", b =>
                {
                    b.HasOne("GameStore.Domain.Entities.AllGames", "AllGames")
                        .WithMany("Shares")
                        .HasForeignKey("AllGamesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
