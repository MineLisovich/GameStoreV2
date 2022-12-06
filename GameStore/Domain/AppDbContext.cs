using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStore.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.Sig;

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
                Ganresid = 103,
                descriptionG = "Cyberpunk 2077 — приключенческая ролевая игра, действие которой происходит в мегаполисе Найт-Сити, где власть, роскошь и модификации тела ценятся выше всего. Вы играете за V, наёмника в поисках устройства, позволяющего обрести бессмертие. Вы сможете менять киберимпланты, навыки и стиль игры своего персонажа, исследуя открытый мир, где ваши поступки влияют на ход сюжета и всё, что вас окружает.",
                releaseDate = new DateTime(2020, 12, 10),
                Developersid = 214,
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
                VRAM = "Nvidia GeForce GTX 1660 GP 6GB GDDR6",
                GameWeight = 80,
                features = "Для одного игрока"
            }); 
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 402,
                nameGame = "Grand Theft Auto V",
                Ganresid = 101,
                descriptionG = "Действие игры происходит в вымышленном штате Сан-Андреас, прообразом которого послужила Южная Калифорния. Сюжет в однопользовательском режиме строится вокруг приключений троих грабителей, устраивающих всё более дерзкие ограбления и противостоящих как организованной преступности, так и правоохранительным ведомствам. В процессе игры игрок управляет выбранным персонажем в режиме от первого или от третьего лица; персонаж может свободно передвигаться по обширному миру игры как пешком, так и на автомобилях и других видах транспорта. Особенностью Grand Theft Auto V по сравнению с другими играми серии является возможность переключаться между персонажами в любой момент, как во время выполнения заданий, так и вне их. Многие задания игры связаны с ограблениями и угоном автомобилей; при этом игровой персонаж может участвовать в перестрелках и погонях. Grand Theft Auto Online представляет собой встроенный многопользовательский онлайн-режим, поддерживающий до 30 игроков одновременно — для них предлагаются как кооперативные, так и соревновательные задания.",
                releaseDate = new DateTime(2013, 12, 17),
                Developersid = 205,
                price = 67,
                Poster = "GTA5.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 304,
                screenshotGame_1 = "GTAV_screenshotGame_1.png",
                screenshotGame_2 = "GTAV_screenshotGame_2.png",
                screenshotGame_3 = "GTAV_screenshotGame_3.png",
                screenshotGame_4 = "GTAV_screenshotGame_4.png",               
                linkTrailerGame = "QkkoHAzjnUs",
                OS = "Windows 7 64 bit / Windows 10 64 bit",
                CPU = "Intel® Core™ 2 Q6600 / AMD Phenom 9850",
                RAM = 4,
                VRAM = "NVIDIA® 9800 GT / AMD HD 4870",
                GameWeight = 110,
                features = "Для нескольких игроков / Для одного игрока"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 403,
                nameGame = "Valheim",
                Ganresid = 103,
                descriptionG = "Вальхейм — это игра, в которой вам предстоит исследовать огромный фэнтезийный мир, пропитанный скандинавской мифологией и культурой викингов. Ваше приключение начнется в самом сердце Вальхейма, месте довольно спокойном. Но берегитесь, ведь чем дальше вы будете продвигаться, тем опаснее будет становиться мир вокруг. К счастью, по пути вас будут ждать не только опасности — вы также будете чаще находить ценные материалы, которые весьма пригодятся для создания смертоносного оружия и крепкой брони. Возводите крепости и заставы по всему миру! А со временем постройте несокрушимый драккар и отправьтесь покорять бескрайние океаны в поиске чужестранных земель... Но постарайтесь не заплыть слишком далеко...",
                releaseDate = new DateTime(2021, 02, 02),
                Developersid = 215,
                price = 25,
                Poster = "Valheim.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 = "Valheim_screenshotGame_1.png",
                screenshotGame_2 = "Valheim_screenshotGame_2.png",
                screenshotGame_3 = "Valheim_screenshotGame_3.png",
                screenshotGame_4 = "Valheim_screenshotGame_4.png",
                linkTrailerGame = "5mHRJ1KFe20",
                OS = "Windows 7 64 bit",
                CPU = "2.6 GHz Quad Core or similar",
                RAM = 8,
                VRAM = "GeForce GTX 950 or Radeon HD 7970",
                GameWeight = 2,
                features = "Для нескольких игроков"

            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 404,
                nameGame = "Assassin’s Creed",
                Ganresid = 101,
                descriptionG = "Действие игры разворачивается во времена Третьего крестового похода, а именно в 1191 году. В настоящем времени бармена Дезмонда Майлса, главного героя, похищает корпорация «Абстерго», которая с помощью Анимуса, машины для извлечения генетической памяти, хочет найти артефакт Первой Цивилизации. В курс дела Дезмонда вводят учёный Уоррен Видик и его ассистентка Люси Стиллман. Они рассказывают ему, что он является потомком ассасина Альтаира ибн-Ла-Ахада, который обнаружил артефакт, и через него хотят узнать местонахождение артефакта.",
                releaseDate = new DateTime(2007, 11, 13),
                Developersid = 206,
                price = 13,  
                Poster = "Assassin1.png",
                dateAddedSite = new DateTime(2022, 04, 03),
                Platformsid = 306,
                screenshotGame_1 = "Assassin1_screenshotGame_1.png",
                screenshotGame_2 = "Assassin1_screenshotGame_2.png",
                screenshotGame_3 = "Assassin1_screenshotGame_3.png",
                screenshotGame_4 = "Assassin1_screenshotGame_4.png",
                linkTrailerGame = "RjQ6ZtyXoA0",
                OS = "Windows XP/Vista / Windows 7",
                CPU = "Dual core (Intel Pentium D или лучше)",
                RAM = 2,
                VRAM = "256MB с поддержкой Shader Model 3.0 или выше",
                GameWeight = 16,
                features = "Для одного игрока"

            });

            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 405,
                nameGame = "Fallout 76",
                Ganresid = 103,
                descriptionG = "События игры происходят в 2102 году в Западной Виргинии. Игрок — житель Убежища 76 (Резидент), проспавший выход на поверхность. Находя голозаписи Смотрительницы Убежища, которая покинула его раньше всех, игрок понимает, что над регионом нависла опасность в виде горелых — людей, заражённых инфекцией, превращающихся со временем в неподвижные статуи, которые, распадаясь, разносят заразу, заражая как и других существ, так и людей. Как выясняется, источник той болезни — зверожоги. Это мутировавшие драконоподобные летучие мыши, обитавшие под землёй. По мере продвижения по сюжету и выполнению квестов игрок создаёт вакцину против чумы зверожогов. Далее Резиденту предстоит проникнуть в хорошо спрятанный бункер «Анклава» — бывшего правительства США. Там ему встречается МОДУС — суперкомпьютер, который убил всех членов Анклава в качестве мести за попытку уничтожить его. МОДУС рассказывает о ядерных ракетах и как их запустить. Игрок завладевает кодами запуска и, проведя бомбардировку главного разлома, откуда вылезают зверожоги, сталкивается с ещё более страшной угрозой — маткой зверожогов. В тяжёлом бою её удаётся убить, и зверожоги, оставшись без главы, разлетаются подобно муравьям, оставшимся без королевы.",
                releaseDate = new DateTime(2018, 10, 23),
                Developersid = 201,
                price = 70,
                Poster = "Fallout76.png",
                dateAddedSite = new DateTime(2022, 04, 03),
                Platformsid = 301,
                screenshotGame_1 = "Fallout76Screenshot_1.png",
                screenshotGame_2 = "Fallout76Screenshot_2.png",
                screenshotGame_3 = "Fallout76Screenshot_3.png",
                screenshotGame_4 = "Fallout76Screenshot_4.png",
                linkTrailerGame = "EtiVOmFiWA0",
                OS = "Windows 7/8/8.1/10",
                CPU = "Intel Core i5-6600K",
                RAM = 8,
                VRAM = "NVIDIA GeForce GTX 780",
                GameWeight = 60,
                features = "Для нескольких игроков"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 406,
                nameGame = "Borderlands 3",
                Ganresid = 103,
                descriptionG = "Всеми любимый «шутер с базиллионами лута» возвращается, чтобы порадовать вас несметным множеством убойных стволов и новым крышесносным приключением! Вам предстоит покорить доселе не виданные миры, играя за одного из четырёх новых искателей Хранилища – нереально крутых перцев, у каждого из которых уникальные навыки, способности и модификации. Действуя в одиночку или в компании друзей, вы должны будете дать бой яростным противникам, нагрести побольше трофеев и спасти свой дом от безжалостных психопатов, возглавляющих самую опасную секту в галактике.",
                releaseDate = new DateTime(2019, 09, 13),
                Developersid = 210,
                price = 70,
                Poster = "Borderlands3.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 305,
                screenshotGame_1 = "borderlands3_screenshot_1.png",
                screenshotGame_2 = "borderlands3_screenshot_2.png",
                screenshotGame_3 = "borderlands3_screenshot_3.png",
                screenshotGame_4 = "borderlands3_screenshot_4.png",
                linkTrailerGame = "tQj8CLKoTCs",
                OS = "Windows 7/10 (с последней версией пакета обновлений)",
                CPU = "AMD Ryzen™ 5 2600 (Intel i7-4770)",
                RAM = 16,
                VRAM = "AMD Radeon™ RX 590 (NVIDIA GeForce GTX 1060 6 ГБ)",
                GameWeight = 75,
                features = "Для одного игрока / Для нескольких игроков"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 407,
                nameGame = "Ведьмак 3: Дикая Охота",
                Ganresid = 103,
                descriptionG = "Станьте профессиональным убийцей монстров и отправляйтесь в приключение эпических масштабов! После своего выхода игра «Ведьмак 3: Дикая Охота» (The Witcher 3: Wild Hunt) стала настоящей классикой, получив более 250 наград в номинации «Игра года». Вас ждёт более 100 часов грандиозного приключения по открытому миру, а также сюжетные расширения, которые растянутся ещё на 50 часов игры. Это издание включает в себя весь дополнительный контент: новое оружие, броню, экипировку для компаньонов, новый режим игры и побочные квесты.",
                releaseDate = new DateTime(2014, 05, 20),
                Developersid = 214,
                price = 50,
                Poster = "Witcher3.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 = "witcher3__screenshot_1.png",
                screenshotGame_2 = "witcher3__screenshot_2.png",
                screenshotGame_3 = "witcher3__screenshot_3.png",
                screenshotGame_4 = "witcher3__screenshot_4.png",
                linkTrailerGame = "4ndIeNusRLI",
                OS = "64-разрядная Windows 7, 64-разрядная Windows 8 (8.1) или 64-разрядная Windows 10",
                CPU = "Intel Core i7 3770 с частотой 3,4 ГГц / AMD FX-8350 с частотой 4 ГГц",
                RAM = 8,
                VRAM = "NVIDIA GPU GeForce GTX 770 / AMD GPU Radeon R9 290",
                GameWeight = 77,
                features = "Для одного игрока"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 408,
                nameGame = "Red Dead Redemption 2",
                Ganresid = 101,
                descriptionG = "Америка, 1899 год. Артур Морган и другие подручные Датча ван дер Линде вынуждены пуститься в бега. Их банде предстоит участвовать в кражах, грабежах и перестрелках в самом сердце Америки. За ними по пятам идут федеральные агенты и лучшие в стране охотники за головами, а саму банду разрывают внутренние противоречия. Артуру предстоит выбрать, что для него важнее: его собственные идеалы или же верность людям, которые его взрастили.",
                releaseDate = new DateTime(2019, 11, 05),
                Developersid = 205,
                price = 80,
                Poster = "rdr2.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 304,
                screenshotGame_1 = "RDR2_screenshot_1.png",
                screenshotGame_2 = "RDR2_screenshot_2.png",
                screenshotGame_3 = "RDR2_screenshot_3.png",
                screenshotGame_4 = "RDR2_screenshot_4.png",
                linkTrailerGame = "0kqEBOZaP94",
                OS = "Windows 10 - April 2018 Update (v1803)",
                CPU = "Intel® Core™ i7-4770K / AMD Ryzen 5 1500x",
                RAM = 12,
                VRAM = "Nvidia GeForce GTX 1060 6 ГБ / AMD Radeon RX 480 4 ГБ",
                GameWeight = 150,
                features = "Для одного игрока / Для нескольких игроков"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 409,
                nameGame = "Tom Clancy's The Division®2",
                Ganresid = 101,
                descriptionG = "Вашингтон на грани катастрофы. Нашему обществу угрожает беззаконие и нестабильность, и слухи о перевороте в Капитолии только способствуют хаосу. Мы крайне нуждаемся в каждом действующем агенте группы Division — только с ними мы сможем спасти город, пока не поздно.",
                releaseDate = new DateTime(2019, 03, 15),
                Developersid = 206,
                price = 40,
                Poster = "Division2.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 306,
                screenshotGame_1 = "thedivision2_screenshot_1.png",
                screenshotGame_2 = "thedivision2_screenshot_2.png",
                screenshotGame_3 = "thedivision2_screenshot_3.png",
                screenshotGame_4 = "thedivision2_screenshot_4.png",
                linkTrailerGame = "ssyC-QwcPug",
                OS = "Windows 7/8/10",
                CPU = "AMD Ryzen 5 1500X | Intel Core I7-4790",
                RAM = 8,
                VRAM = "AMD RX 480 NVIDIA GeForce GTX 970",
                GameWeight = 4,
                features = "Для нескольких игроков"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 410,
                nameGame = "Fallout 4",
                Ganresid = 103,
                descriptionG = "Добро пожаловать в игру нового поколения с открытым миром! Вы — единственный выживший из убежища 111, оказавшийся в мире, разрушенном ядерной войной. Каждый миг вы сражаетесь за выживание, каждое решение может стать последним. Но именно от вас зависит судьба пустошей. Добро пожаловать домой.",
                releaseDate = new DateTime(2015, 11, 10),
                Developersid =201,
                price = 50,
                Poster = "Fallout4.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 = "fallout4_1.png",
                screenshotGame_2 = "fallout4_2.png",
                screenshotGame_3 = "fallout4_3.png",
                screenshotGame_4 = "fallout4_4.png",
                linkTrailerGame = "ErgtR14-MV8",
                OS = "Windows 7/8/10/11 (необходима 64-битная ОС)",
                CPU = "Intel Core i5-2300 2,8 ГГц/AMD Phenom II X4 945 3 ГГц",
                RAM = 8,
                VRAM = "NVIDIA GTX 550 Ti 2 Гб/AMD Radeon HD 7870 2 Гб",
                GameWeight = 60,
                features = "Для одного игрока"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 411,
                nameGame = "The Elder Scrolls V: Skyrim",
                Ganresid = 102,
                descriptionG = "Эта часть, как и предыдущие три игры серии — The Elder Scrolls II: Daggerfall, The Elder Scrolls III: Morrowind и The Elder Scrolls IV: Oblivion — получила титул «Игра года» на Video Game Award 2011. Действие происходит через 200 лет после событий Oblivion. Игра была анонсирована 11 ноября 2010 года, а выпущена 11 ноября 2011 года. В игре задействован новый движок Creation Engine и обновлённая система мелких квестов Radiant Story.",
                releaseDate = new DateTime(2016, 10, 11),
                Developersid = 201,
                price = 50,
                Poster = "The_Elder_Scrolls_V_Skyrim.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 301,
                screenshotGame_1 = "Skyrim_1.png",
                screenshotGame_2 = "Skyrim_2.png",
                screenshotGame_3 = "Skyrim_3.png",
                screenshotGame_4 = "Skyrim_4.png",
                linkTrailerGame = "JSRtYpNRoN0",
                OS = "Windows 7/8.1/10 (64-разрядные версии)",
                CPU = "Intel i5-2400 или AMD FX-8320",
                RAM = 0,
                VRAM = "NVIDIA GTX 780 (3 ГБ) AMD R9 290 (4 ГБ)",
                GameWeight = 15,
                features = "Для одного игрока"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 412,
                nameGame = "Far Cry® 6",
                Ganresid = 101,
                descriptionG = "Добро пожаловать в Яру – тропический рай, где время словно остановилось. Диктатор Антон Кастильо намерен любой ценой вернуть былое величие нации. За ним следует его сын – Диего. Но в угнетенной стране вспыхнуло пламя революции.",
                releaseDate = new DateTime(2021, 10, 07),
                Developersid = 206,
                price = 80,
                Poster = "FarCry6_poster.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 305,
                screenshotGame_1 = "FarCry6_1.png",
                screenshotGame_2 = "FarCry6_2.png",
                screenshotGame_3 = "FarCry6_3.png",
                screenshotGame_4 = "FarCry6_4.png",
                linkTrailerGame = "YqDpa6gHAZg",
                OS = "Windows 10 (версия 20H1 или новее) — только 64-разрядная версия",
                CPU = "AMD Ryzen 5 3600X с частотой 3,8 ГГц / Intel i7-7700 с частотой 3,6 ГГц или выше",
                RAM = 16,
                VRAM = "AMD RX VEGA 64 (8 ГБ) / NVIDIA GTX 1080 (8 ГБ) или выше",
                GameWeight = 60,
                features = "Для одного игрока / Для нескольких игроков"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 413,
                nameGame = "Far Cry® 5",
                Ganresid = 101,
                descriptionG = "Добро пожаловать в округ Хоуп, штат Монтана, земли свободолюбцев и храбрецов, где всем заправляет секта конца света «Врата Эдема».Освободите округ Хоуп в одиночку или вместе с другим игроком. Пользуйтесь услугами наёмников и приручайте животных, чтобы уничтожить секту.",
                releaseDate = new DateTime(2018, 03, 27),
                Developersid = 206,
                price = 65,
                Poster = "Far_Cry_5.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 305,
                screenshotGame_1 = "FarCry5_1.png",
                screenshotGame_2 = "FarCry5_2.png",
                screenshotGame_3 = "FarCry5_3.png",
                screenshotGame_4 = "FarCry5_4.png",
                linkTrailerGame = "ZCBC2kN33jw",
                OS = "Windows 7 SP1 | Windows 8.1 | Windows 10 | Только 64-разрядные версии",
                CPU = "Intel Core i7-4770 с частотой 3,4 ГГц | AMD Ryzen 5 1600 с частотой 3,2 ГГц или эквивалентный",
                RAM = 8,
                VRAM = "NVIDIA GeForce GTX 970 | AMD R9 290X",
                GameWeight = 40,
                features = "Для одного игрока / Для нескольких игроков"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {
                id = 414,
                nameGame = "Assassin's Creed Origins",
                Ganresid = 103,
                descriptionG = "Раскройте темные тайны и забытые мифы, возвращаясь к моменту основания: Истоки Братства ассасинов. Испытайте совершенно новый способ ведения боя. Добывайте и используйте десятки видов оружия с различными характеристиками и редкостями.Плывите вниз по Нилу, раскройте тайны пирамид или сражайтесь с опасными древними группировками и дикими зверями, исследуя эту гигантскую и непредсказуемую страну.",
                releaseDate = new DateTime(2017, 10, 26),
                Developersid = 206,
                price = 65,
                Poster = "Assassin_Origins.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 306,
                screenshotGame_1 = "Assassin_Origins_1.png",
                screenshotGame_2 = "Assassin_Origins_2.png",
                screenshotGame_3 = "Assassin_Origins_3.png",
                screenshotGame_4 = "Assassin_Origins_4.png",
                linkTrailerGame = "x_1GwlWSil4",
                OS = "Windows 7 SP1 | Windows 8.1, Windows 10 | только 64-разрядная версия",
                CPU = "Intel Core i5-2400s с частотой 2,5 ГГц | AMD FX-6350 с частотой 3,9 ГГц или эквивалент",
                RAM = 8,
                VRAM = "NVIDIA GeForce GTX 760 или AMD R9 270/2048 МБ видеопамяти с шейдерной моделью 5.0 или выше",
                GameWeight = 42,
                features = "Для одного игрока"
            });
            modelBuilder.Entity<AllGames>().HasData(new AllGames
            {

                id = 415,
                nameGame = "Assassin's Creed Odyssey",
                Ganresid = 103,
                descriptionG = "Определите свою судьбу в игре Assassin's Creed® Одиссея. Пройдите путь от изгоя до живой легенды: отправьтесь в далёкое странствие, чтобы раскрыть тайны своего прошлого и изменить будущее Древней Греции. Путешествуйте по густым зелёным лесам, вулканическим островам и шумным городам — встаньте на путь открытий и встреч в мире, что погряз в войне, начатой богами и людьми.",
                releaseDate = new DateTime(2018, 10, 05),
                Developersid = 206,
                price = 65,
                Poster = "Assassins_Creed_Odyssey.png",
                dateAddedSite = new DateTime(2022, 03, 03),
                Platformsid = 306,
                screenshotGame_1 = "Assassins_Creed_Odyssey_1.png",
                screenshotGame_2 = "Assassins_Creed_Odyssey_2.png",
                screenshotGame_3 = "Assassins_Creed_Odyssey_3.png",
                screenshotGame_4 = "Assassins_Creed_Odyssey_4.png",
                linkTrailerGame = "AQaSqKjbX60",
                OS = "Windows 7 с пакетом обновления 1 (SP1), Windows 8.1, Windows 10 | Только 64-разрядные версии",
                CPU = "Не ниже AMD FX-8350 с частотой 4 ГГц | Ryzen 5 — 1400 | Intel Core i7-3770 с частотой 3,5 ГГц",
                RAM = 8,
                VRAM = "AMD Radeon R9 285 | NVIDIA GeForce GTX 660 | 2 ГБ видеопамяти и Shader Model 5.0",
                GameWeight = 46,
                features = "Для одного игрока"
            });
            //Заполение таблицы Shares
            modelBuilder.Entity<Shares>().HasData(new Shares
            {
                id = 501,
                AllGamesid = 401,
                discountPrice = 30,
                nameImageSlider = "2077.png"
            });
            modelBuilder.Entity<Shares>().HasData(new Shares
            {
                id = 502,
                AllGamesid = 405,
                discountPrice = 55,
                nameImageSlider = "Fallout76.png"
            });
            modelBuilder.Entity<Shares>().HasData(new Shares
            {
                id = 503,
                AllGamesid = 408,
                discountPrice = 70,
                nameImageSlider = "rdr2.png"
            });
            modelBuilder.Entity<Shares>().HasData(new Shares
            {
                id = 504,
                AllGamesid = 407,
                discountPrice = 30,
                nameImageSlider = "Wicher3.png"
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

            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 901,
                Key_game = "GHZNAZXB-ZXNHDANX-IOEJZNDG-MSHSJWUJ",
                AllGamesid = 401

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 902,
                Key_game = "IEUWYHDB-DKSNZMEU-XHSKDMWO-XMBADHNR",
                AllGamesid = 402 

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 903,
                Key_game = "ZXNEYTAB-KFBSYDBF-XHSNWDAC-DNWHDDEWE",
                AllGamesid =403

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 904,
                Key_game = "FJNVCDKM-KLWDEIRU-SXJNHWEG-SAJKFHJD",
                AllGamesid =404

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 905,
                Key_game = "GRHUSDNM-CXJNWGVD-DJNCLKWD-WEYUXZBN",
                AllGamesid =405

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 906,
                Key_game = "RTIOSDBN-REHJNMSAX-REUYBSXN-DSHJVBWE",
                AllGamesid =406

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 907,
                Key_game = "REYUCBXN-YUEWVSBA-SAHJWVBQ-OXZIQVWB",
                AllGamesid =407

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 908,
                Key_game = "VFBNYTWE-DSHJWQVB-DISUQWVB-KSJAEWBV",
                AllGamesid =408

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 909,
                Key_game = "CXBNWJHE-KFJHDHJWFEK-HWEJRF-WHKFEUJ",
                AllGamesid =409

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 910,
                Key_game = "WFOQEUIFHW-KWEFHJ-BEWFJH-WEFVHGJ",
                AllGamesid =410

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 911,
                Key_game = "FWGYURQ-FEBVWQUY-QJHFG-QYUWEBN",
                AllGamesid =411

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 912,
                Key_game = "GYWUI-WBKFEJ-REYUWI-BHSAJ-URYIWQE",
                AllGamesid =412

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 913,
                Key_game = "WIUETYR-AKFHGEW-HBJWRE-WRKQEJH",
                AllGamesid =413

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 914,
                Key_game = "WHEFJK-EWRBKJH-UIWYRQE-CBXZJHSD-EFWUIY",
                AllGamesid =414

            });
            modelBuilder.Entity<GameKey>().HasData(new GameKey
            {
                id = 915,
                Key_game = "RVUIEHG-0EFWIUY-WEHKFUJ-JKDSIJFSDO",
                AllGamesid =415

            });


            //Заполение таблицы Basket
            modelBuilder.Entity<Basket>().HasData(new Basket
            {
                id = 801,
                AllGamesid = 401,
                UserId = "702",
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
