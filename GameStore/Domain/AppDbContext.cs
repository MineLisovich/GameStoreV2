using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStore.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>// DbContext//
    {
     

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<AllGames> AllGames { get; set; }  
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Developers> Developers { get; set; }
        public DbSet<Ganres> Ganres { get; set; }   
        public DbSet<Platforms> Platforms { get; set; }
        public DbSet<Shares> Shares { get; set; }
        public DbSet<GameKey> GameKey { get; set; }
        public DbSet<Chek> Chek { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Заполение таблицы Ganres
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
               id = 101,
               nameGanres = "Экшн"
            });
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
                id = 102,
                nameGanres = "Приключения"
            });
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
                id = 103,
                nameGanres = "RPG"
            });
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
                id = 104,
                nameGanres = "Симуляторы"
            });
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
                id = 105,
                nameGanres = "Спорт"
            });
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
                id = 106,
                nameGanres = "Гонки"
            });
            modelBuilder.Entity<Ganres>().HasData(new Ganres
            {
                id = 107,
                nameGanres = "Казуал"
            });


            //Заполение таблицы Developers
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id =201,
                nameDeveloper = "Bethesda"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 202,
                nameDeveloper = "Blizzard"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 203,
                nameDeveloper = "Valve"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 204,
                nameDeveloper = "Electronic Arts"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 205,
                nameDeveloper = "RockStar Games"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 206,
                nameDeveloper = "Ubisoft"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 207,
                nameDeveloper = "Square Enix"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 208,
                nameDeveloper = "Activision"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 209,
                nameDeveloper = "Konami"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 210,
                nameDeveloper = "2K Games"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 211,
                nameDeveloper = "Matrix Games"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 212,
                nameDeveloper = "Nacon"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 213,
                nameDeveloper = "Majesco"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 214,
                nameDeveloper = "CD Projekt Red"
            });
            modelBuilder.Entity<Developers>().HasData(new Developers
            {
                id = 215,
                nameDeveloper = "Iron Gate AB"
            });

            //Заполение таблицы Platforms
            modelBuilder.Entity<Platforms>().HasData(new Platforms
            {
                id = 301,
                namePlatform = "Steam"
            });
            modelBuilder.Entity<Platforms>().HasData(new Platforms
            {
                id = 302,
                namePlatform = "Origin"
            });
            modelBuilder.Entity<Platforms>().HasData(new Platforms
            {
                id = 303,
                namePlatform = "Battle.net"
            });
            modelBuilder.Entity<Platforms>().HasData(new Platforms
            {
                id = 304,
                namePlatform = "RockStar Launcher"
            });
            modelBuilder.Entity<Platforms>().HasData(new Platforms
            {
                id = 305,
                namePlatform = "Epic Games Launcher"
            });
            modelBuilder.Entity<Platforms>().HasData(new Platforms
            {
                id = 306,
                namePlatform = "Ubisoft Connect"
            });

            //Заполение таблицы AllGames
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
               
                id = 401,
                nameGame = "Cyberpunk 2077",
                Ganresid = 101,
                descriptionG = " Cyberpunk 2077 — компьютерная игра в жанре экшен в открытом мире, разработанная и изданная польской студией CD Projekt. Действие игры происходит в 2077 году в Найт-Сити, вымышленном североамериканском городе из вселенной Cyberpunk.",
                releaseDate = new DateTime(2020, 12, 10),
                Developersid = 201,
                price = 34,
                Poster = "2077.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 ="Cyberpunk_screenshotGame_1.png",
                screenshotGame_2 = "Cyberpunk_screenshotGame_2.png",
                screenshotGame_3 = "Cyberpunk_screenshotGame_3.png",
                screenshotGame_4 = "Cyberpunk_screenshotGame_4.png",
                linkTrailerGame= "aSrFWinrkeQ",
                OS = "Windows 10 64 bit",
                CPU = "Intel Core i5-11400F or AMD Ryzen 5 5600X",
                RAM = 8,
                VRAM = "Nvidia GeForce GTX 1650 GP 4GB GDDR6",
                GameWeight = 14
            }); 
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 402,
                nameGame = "Grand Theft Auto V",
                Ganresid = 101,
                descriptionG = "GTA V — компьютерная игра в жанре action-adventure с открытым миром, разработанная компанией Rockstar North и изданная компанией Rockstar Games.",
                releaseDate = new DateTime(2013, 12, 17),
                Developersid = 201,
                price = 25,
                Poster = "GTA5.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 = "GTAV_screenshotGame_1.png",
                screenshotGame_2 = "GTAV_screenshotGame_2.png",
                screenshotGame_3 = "GTAV_screenshotGame_3.png",
                screenshotGame_4 = "GTAV_screenshotGame_4.png",               
                linkTrailerGame = "QkkoHAzjnUs",
                OS = "Windows 10 64 bit",
                CPU = "Intel Core i5-11400F or AMD Ryzen 5 5600X",
                RAM = 8,
                VRAM = "Nvidia GeForce GTX 1650 GP 4GB GDDR6",
                GameWeight = 14
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 403,
                nameGame = "Valheim",
                Ganresid = 101,
                descriptionG = "Valheim — компьютерная игра в жанре симулятора выживания в открытом мире, разрабатываемая шведской компанией Iron Gate и изданная компанией Coffee Stain.",
                releaseDate = new DateTime(2021, 02, 02),
                Developersid = 201,
                price = 10,
                Poster = "Valheim.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 = "Valheim_screenshotGame_1.png",
                screenshotGame_2 = "Valheim_screenshotGame_2.png",
                screenshotGame_3 = "Valheim_screenshotGame_3.png",
                screenshotGame_4 = "Valheim_screenshotGame_4.png",
                linkTrailerGame = "5mHRJ1KFe20",
                OS = "Windows 10 64 bit",
                CPU = "Intel Core i5-11400F or AMD Ryzen 5 5600X",
                RAM = 8,
                VRAM = "Nvidia GeForce GTX 1650 GP 4GB GDDR6",
                GameWeight = 14
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 404,
                nameGame = "Assassin’s Creed",
                Ganresid = 101,
                descriptionG = "Действие игры разворачивается во времена Третьего крестового похода, а именно в 1191 году. В настоящем времени бармена Дезмонда Майлса, главного героя, похищает корпорация «Абстерго», которая с помощью Анимуса, машины для извлечения генетической памяти, хочет найти артефакт Первой Цивилизации. В курс дела Дезмонда вводят учёный Уоррен Видик и его ассистентка Люси Стиллман. Они рассказывают ему, что он является потомком ассасина Альтаира ибн-Ла-Ахада, который обнаружил артефакт, и через него хотят узнать местонахождение артефакта.",
                releaseDate = new DateTime(2007, 11, 13),
                Developersid = 201,
                price = 13,  
                Poster = "Assassin1.png",
                dateAddedSite = new DateTime(2022, 04, 03),
                Platformsid = 301,
                screenshotGame_1 = "Assassin1_screenshotGame_1.png",
                screenshotGame_2 = "Assassin1_screenshotGame_2.png",
                screenshotGame_3 = "Assassin1_screenshotGame_3.png",
                screenshotGame_4 = "Assassin1_screenshotGame_4.png",
                linkTrailerGame = "RjQ6ZtyXoA0",
                OS = "Windows 10 64 bit",
                CPU = "Intel Core i5-11400F or AMD Ryzen 5 5600X",
                RAM = 8,
                VRAM = "Nvidia GeForce GTX 1650 GP 4GB GDDR6",
                GameWeight = 14

            });

            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 405,
                nameGame = "Fallout 76",
                Ganresid = 101,
                descriptionG = "События игры происходят в 2102 году в Западной Виргинии. Игрок — житель Убежища 76 (Резидент), проспавший выход на поверхность. Находя голозаписи Смотрительницы Убежища, которая покинула его раньше всех, игрок понимает, что над регионом нависла опасность в виде горелых — людей, заражённых инфекцией, превращающихся со временем в неподвижные статуи, которые, распадаясь, разносят заразу, заражая как и других существ, так и людей. Как выясняется, источник той болезни — зверожоги. Это мутировавшие драконоподобные летучие мыши, обитавшие под землёй. По мере продвижения по сюжету и выполнению квестов игрок создаёт вакцину против чумы зверожогов. Далее Резиденту предстоит проникнуть в хорошо спрятанный бункер «Анклава» — бывшего правительства США. Там ему встречается МОДУС — суперкомпьютер, который убил всех членов Анклава в качестве мести за попытку уничтожить его. МОДУС рассказывает о ядерных ракетах и как их запустить. Игрок завладевает кодами запуска и, проведя бомбардировку главного разлома, откуда вылезают зверожоги, сталкивается с ещё более страшной угрозой — маткой зверожогов. В тяжёлом бою её удаётся убить, и зверожоги, оставшись без главы, разлетаются подобно муравьям, оставшимся без королевы.",
                releaseDate = new DateTime(2018, 10, 23),
                Developersid = 201,
                price = 55,
                Poster = "Fallout76.png",
                dateAddedSite = new DateTime(2022, 04, 03),
                Platformsid = 301,
                screenshotGame_1 = "Fallout76Screenshot_1.png",
                screenshotGame_2 = "Fallout76Screenshot_2.png",
                screenshotGame_3 = "Fallout76Screenshot_3.png",
                screenshotGame_4 = "Fallout76Screenshot_4.png",
                linkTrailerGame = "RjQ6ZtyXoA0",
                OS = "Windows 10 64 bit",
                CPU = "Intel Core i5-11400F or AMD Ryzen 5 5600X",
                RAM = 8,
                VRAM = "Nvidia GeForce GTX 1650 GP 4GB GDDR6",
                GameWeight = 14
            });

            //Заполение таблицы Shares
            modelBuilder.Entity<Shares>().HasData(new Shares
            {
                id = 501,
                AllGamesid = 401,
                discountPrice = 3,
                nameImageSlider = "name1.png"
            });

            //
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "601",
                Name = "admin",
                NormalizedName = "ADMIN"

            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "602",
                Name = "user",
                NormalizedName = "USER",

            });
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "701",
                UserName = "deeLimpay",
                NormalizedUserName = "deeLimpay",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin1"),
                SecurityStamp = string.Empty,
                Email = "deeLimpay@mail.ru",
                NormalizedEmail = "deeLimpay@mail.ru",
                EmailConfirmed = true,
            });


            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "702",
                UserName = "Stepashka",
                NormalizedUserName = "Stepashka",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "user11"),
                SecurityStamp = string.Empty,
                Email = "stepa@gmail.com",
                NormalizedEmail = "stepa@gmail.com",
                EmailConfirmed = true,


            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "701",
                RoleId = "601"

            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "702",
                RoleId = "602"

            });

         

            //

            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 901,
                Key_game = "XXXX-XXXX-XXXX",
                AllGamesid = 401

            });

            //Заполение таблицы Basket
            modelBuilder.Entity<Basket>().HasData(new Basket
            {
                id = 801,
                AllGamesid = 401,
                UserId = "702",
                amount = 1,
                finalPrice = 3
            });

            //Заполение таблицы Chek
            modelBuilder.Entity<Chek>().HasData(new Chek
            {
                id = 1001,
                dateAddedCheque = new DateTime(2022, 07, 29),
                UserId = "702",
                nameGame = "Cyberpunk 2077",
                GameKeyid = 901,
                priceGame = 24,
                
            });
        }


    }
}
