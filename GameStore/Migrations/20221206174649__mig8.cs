using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Migrations
{
    public partial class _mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameDeveloper = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ganres",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameGanres = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namePlatform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllGames",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameGame = table.Column<string>(nullable: false),
                    descriptionG = table.Column<string>(nullable: false),
                    releaseDate = table.Column<DateTime>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    Poster = table.Column<string>(nullable: true),
                    dateAddedSite = table.Column<DateTime>(nullable: false),
                    screenshotGame_1 = table.Column<string>(nullable: true),
                    screenshotGame_2 = table.Column<string>(nullable: true),
                    screenshotGame_3 = table.Column<string>(nullable: true),
                    screenshotGame_4 = table.Column<string>(nullable: true),
                    linkTrailerGame = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: false),
                    CPU = table.Column<string>(nullable: false),
                    RAM = table.Column<int>(nullable: false),
                    VRAM = table.Column<string>(nullable: false),
                    GameWeight = table.Column<int>(nullable: false),
                    features = table.Column<string>(nullable: false),
                    Ganresid = table.Column<int>(nullable: false),
                    Developersid = table.Column<int>(nullable: false),
                    Platformsid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllGames", x => x.id);
                    table.ForeignKey(
                        name: "FK_AllGames_Developers_Developersid",
                        column: x => x.Developersid,
                        principalTable: "Developers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllGames_Ganres_Ganresid",
                        column: x => x.Ganresid,
                        principalTable: "Ganres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllGames_Platforms_Platformsid",
                        column: x => x.Platformsid,
                        principalTable: "Platforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    finalPrice = table.Column<int>(nullable: false),
                    AllGamesid = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.id);
                    table.ForeignKey(
                        name: "FK_Basket_AllGames_AllGamesid",
                        column: x => x.AllGamesid,
                        principalTable: "AllGames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basket_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameKey",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key_game = table.Column<string>(nullable: false),
                    AllGamesid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameKey", x => x.id);
                    table.ForeignKey(
                        name: "FK_GameKey_AllGames_AllGamesid",
                        column: x => x.AllGamesid,
                        principalTable: "AllGames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discountPrice = table.Column<int>(nullable: false),
                    nameImageSlider = table.Column<string>(nullable: false),
                    AllGamesid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shares_AllGames_AllGamesid",
                        column: x => x.AllGamesid,
                        principalTable: "AllGames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chek",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateAddedCheque = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    nameGame = table.Column<string>(nullable: false),
                    priceGame = table.Column<int>(nullable: false),
                    GameKeyid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chek", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chek_GameKey_GameKeyid",
                        column: x => x.GameKeyid,
                        principalTable: "GameKey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chek_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "602", "2e3c8de4-dacb-4535-a27d-865174745ffb", "user", "USER" },
                    { "601", "d88b7adb-8633-405f-b8be-70da2d49f9ad", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "702", 0, "434d3da7-a471-4462-b0c1-73b43beb119c", "stepa@gmail.com", true, false, null, "stepa@gmail.com", "Stepashka", "AQAAAAEAACcQAAAAEBvnhjqAdxxhjFqT49bdwzZJ6AXoVeddlXSRgPUgn5p2fpTeNHavIJuCqU2E3oyZwg==", null, false, "", false, "Stepashka" },
                    { "701", 0, "63a054b6-2a84-4c56-baac-c0404e02b168", "deeLimpay@mail.ru", true, false, null, "deeLimpay@mail.ru", "deeLimpay", "AQAAAAEAACcQAAAAEBUiYSAwO2OjPVXCs0XBr5VOsGp8mlClmcgotoPUflgX+K23usU4mDRf2AUjen+SzA==", null, false, "", false, "deeLimpay" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "id", "nameDeveloper" },
                values: new object[,]
                {
                    { 215, "Iron Gate AB" },
                    { 214, "CD Projekt Red" },
                    { 213, "Majesco" },
                    { 212, "Nacon" },
                    { 211, "Matrix Games" },
                    { 201, "Bethesda" },
                    { 209, "Konami" },
                    { 208, "Activision" },
                    { 207, "Square Enix" },
                    { 206, "Ubisoft" },
                    { 205, "RockStar Games" },
                    { 204, "Electronic Arts" },
                    { 202, "Blizzard" },
                    { 203, "Valve" },
                    { 210, "2K Games" }
                });

            migrationBuilder.InsertData(
                table: "Ganres",
                columns: new[] { "id", "nameGanres" },
                values: new object[,]
                {
                    { 107, "Казуал" },
                    { 106, "Гонки" },
                    { 104, "Симуляторы" },
                    { 103, "RPG" },
                    { 102, "Приключения" },
                    { 105, "Спорт" },
                    { 101, "Экшн" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "id", "namePlatform" },
                values: new object[,]
                {
                    { 301, "Steam" },
                    { 302, "Origin" },
                    { 303, "Battle.net" },
                    { 304, "RockStar Launcher" },
                    { 305, "Epic Games Launcher" },
                    { 306, "Ubisoft Connect" }
                });

            migrationBuilder.InsertData(
                table: "AllGames",
                columns: new[] { "id", "CPU", "Developersid", "GameWeight", "Ganresid", "OS", "Platformsid", "Poster", "RAM", "VRAM", "dateAddedSite", "descriptionG", "features", "linkTrailerGame", "nameGame", "price", "releaseDate", "screenshotGame_1", "screenshotGame_2", "screenshotGame_3", "screenshotGame_4" },
                values: new object[,]
                {
                    { 401, "Intel Core i5-11400F or AMD Ryzen 5 5600X", 214, 80, 103, "Windows 10 64 bit", 301, "2077.png", 8, "Nvidia GeForce GTX 1660 GP 6GB GDDR6", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077 — приключенческая ролевая игра, действие которой происходит в мегаполисе Найт-Сити, где власть, роскошь и модификации тела ценятся выше всего. Вы играете за V, наёмника в поисках устройства, позволяющего обрести бессмертие. Вы сможете менять киберимпланты, навыки и стиль игры своего персонажа, исследуя открытый мир, где ваши поступки влияют на ход сюжета и всё, что вас окружает.", "Для одного игрока", "aSrFWinrkeQ", "Cyberpunk 2077", 34, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk_screenshotGame_1.png", "Cyberpunk_screenshotGame_2.png", "Cyberpunk_screenshotGame_3.png", "Cyberpunk_screenshotGame_4.png" },
                    { 415, "Не ниже AMD FX-8350 с частотой 4 ГГц | Ryzen 5 — 1400 | Intel Core i7-3770 с частотой 3,5 ГГц", 206, 46, 103, "Windows 7 с пакетом обновления 1 (SP1), Windows 8.1, Windows 10 | Только 64-разрядные версии", 306, "Assassins_Creed_Odyssey.png", 8, "AMD Radeon R9 285 | NVIDIA GeForce GTX 660 | 2 ГБ видеопамяти и Shader Model 5.0", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Определите свою судьбу в игре Assassin's Creed® Одиссея. Пройдите путь от изгоя до живой легенды: отправьтесь в далёкое странствие, чтобы раскрыть тайны своего прошлого и изменить будущее Древней Греции. Путешествуйте по густым зелёным лесам, вулканическим островам и шумным городам — встаньте на путь открытий и встреч в мире, что погряз в войне, начатой богами и людьми.", "Для одного игрока", "AQaSqKjbX60", "Assassin's Creed Odyssey", 65, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassins_Creed_Odyssey_1.png", "Assassins_Creed_Odyssey_2.png", "Assassins_Creed_Odyssey_3.png", "Assassins_Creed_Odyssey_4.png" },
                    { 414, "Intel Core i5-2400s с частотой 2,5 ГГц | AMD FX-6350 с частотой 3,9 ГГц или эквивалент", 206, 42, 103, "Windows 7 SP1 | Windows 8.1, Windows 10 | только 64-разрядная версия", 306, "Assassin_Origins.png", 8, "NVIDIA GeForce GTX 760 или AMD R9 270/2048 МБ видеопамяти с шейдерной моделью 5.0 или выше", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Раскройте темные тайны и забытые мифы, возвращаясь к моменту основания: Истоки Братства ассасинов. Испытайте совершенно новый способ ведения боя. Добывайте и используйте десятки видов оружия с различными характеристиками и редкостями.Плывите вниз по Нилу, раскройте тайны пирамид или сражайтесь с опасными древними группировками и дикими зверями, исследуя эту гигантскую и непредсказуемую страну.", "Для одного игрока", "x_1GwlWSil4", "Assassin's Creed Origins", 65, new DateTime(2017, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin_Origins_1.png", "Assassin_Origins_2.png", "Assassin_Origins_3.png", "Assassin_Origins_4.png" },
                    { 409, "AMD Ryzen 5 1500X | Intel Core I7-4790", 206, 4, 101, "Windows 7/8/10", 306, "Division2.png", 8, "AMD RX 480 NVIDIA GeForce GTX 970", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вашингтон на грани катастрофы. Нашему обществу угрожает беззаконие и нестабильность, и слухи о перевороте в Капитолии только способствуют хаосу. Мы крайне нуждаемся в каждом действующем агенте группы Division — только с ними мы сможем спасти город, пока не поздно.", "Для нескольких игроков", "ssyC-QwcPug", "Tom Clancy's The Division®2", 40, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "thedivision2_screenshot_1.png", "thedivision2_screenshot_2.png", "thedivision2_screenshot_3.png", "thedivision2_screenshot_4.png" },
                    { 404, "Dual core (Intel Pentium D или лучше)", 206, 16, 101, "Windows XP/Vista / Windows 7", 306, "Assassin1.png", 2, "256MB с поддержкой Shader Model 3.0 или выше", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Действие игры разворачивается во времена Третьего крестового похода, а именно в 1191 году. В настоящем времени бармена Дезмонда Майлса, главного героя, похищает корпорация «Абстерго», которая с помощью Анимуса, машины для извлечения генетической памяти, хочет найти артефакт Первой Цивилизации. В курс дела Дезмонда вводят учёный Уоррен Видик и его ассистентка Люси Стиллман. Они рассказывают ему, что он является потомком ассасина Альтаира ибн-Ла-Ахада, который обнаружил артефакт, и через него хотят узнать местонахождение артефакта.", "Для одного игрока", "RjQ6ZtyXoA0", "Assassin’s Creed", 13, new DateTime(2007, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin1_screenshotGame_1.png", "Assassin1_screenshotGame_2.png", "Assassin1_screenshotGame_3.png", "Assassin1_screenshotGame_4.png" },
                    { 413, "Intel Core i7-4770 с частотой 3,4 ГГц | AMD Ryzen 5 1600 с частотой 3,2 ГГц или эквивалентный", 206, 40, 101, "Windows 7 SP1 | Windows 8.1 | Windows 10 | Только 64-разрядные версии", 305, "Far_Cry_5.png", 8, "NVIDIA GeForce GTX 970 | AMD R9 290X", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Добро пожаловать в округ Хоуп, штат Монтана, земли свободолюбцев и храбрецов, где всем заправляет секта конца света «Врата Эдема».Освободите округ Хоуп в одиночку или вместе с другим игроком. Пользуйтесь услугами наёмников и приручайте животных, чтобы уничтожить секту.", "Для одного игрока / Для нескольких игроков", "ZCBC2kN33jw", "Far Cry® 5", 65, new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FarCry5_1.png", "FarCry5_2.png", "FarCry5_3.png", "FarCry5_4.png" },
                    { 412, "AMD Ryzen 5 3600X с частотой 3,8 ГГц / Intel i7-7700 с частотой 3,6 ГГц или выше", 206, 60, 101, "Windows 10 (версия 20H1 или новее) — только 64-разрядная версия", 305, "FarCry6_poster.png", 16, "AMD RX VEGA 64 (8 ГБ) / NVIDIA GTX 1080 (8 ГБ) или выше", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Добро пожаловать в Яру – тропический рай, где время словно остановилось. Диктатор Антон Кастильо намерен любой ценой вернуть былое величие нации. За ним следует его сын – Диего. Но в угнетенной стране вспыхнуло пламя революции.", "Для одного игрока / Для нескольких игроков", "YqDpa6gHAZg", "Far Cry® 6", 80, new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FarCry6_1.png", "FarCry6_2.png", "FarCry6_3.png", "FarCry6_4.png" },
                    { 406, "AMD Ryzen™ 5 2600 (Intel i7-4770)", 210, 75, 103, "Windows 7/10 (с последней версией пакета обновлений)", 305, "Borderlands3.png", 16, "AMD Radeon™ RX 590 (NVIDIA GeForce GTX 1060 6 ГБ)", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Всеми любимый «шутер с базиллионами лута» возвращается, чтобы порадовать вас несметным множеством убойных стволов и новым крышесносным приключением! Вам предстоит покорить доселе не виданные миры, играя за одного из четырёх новых искателей Хранилища – нереально крутых перцев, у каждого из которых уникальные навыки, способности и модификации. Действуя в одиночку или в компании друзей, вы должны будете дать бой яростным противникам, нагрести побольше трофеев и спасти свой дом от безжалостных психопатов, возглавляющих самую опасную секту в галактике.", "Для одного игрока / Для нескольких игроков", "tQj8CLKoTCs", "Borderlands 3", 70, new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "borderlands3_screenshot_1.png", "borderlands3_screenshot_2.png", "borderlands3_screenshot_3.png", "borderlands3_screenshot_4.png" },
                    { 402, "Intel® Core™ 2 Q6600 / AMD Phenom 9850", 205, 110, 101, "Windows 7 64 bit / Windows 10 64 bit", 304, "GTA5.png", 4, "NVIDIA® 9800 GT / AMD HD 4870", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Действие игры происходит в вымышленном штате Сан-Андреас, прообразом которого послужила Южная Калифорния. Сюжет в однопользовательском режиме строится вокруг приключений троих грабителей, устраивающих всё более дерзкие ограбления и противостоящих как организованной преступности, так и правоохранительным ведомствам. В процессе игры игрок управляет выбранным персонажем в режиме от первого или от третьего лица; персонаж может свободно передвигаться по обширному миру игры как пешком, так и на автомобилях и других видах транспорта. Особенностью Grand Theft Auto V по сравнению с другими играми серии является возможность переключаться между персонажами в любой момент, как во время выполнения заданий, так и вне их. Многие задания игры связаны с ограблениями и угоном автомобилей; при этом игровой персонаж может участвовать в перестрелках и погонях. Grand Theft Auto Online представляет собой встроенный многопользовательский онлайн-режим, поддерживающий до 30 игроков одновременно — для них предлагаются как кооперативные, так и соревновательные задания.", "Для нескольких игроков / Для одного игрока", "QkkoHAzjnUs", "Grand Theft Auto V", 67, new DateTime(2013, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTAV_screenshotGame_1.png", "GTAV_screenshotGame_2.png", "GTAV_screenshotGame_3.png", "GTAV_screenshotGame_4.png" },
                    { 411, "Intel i5-2400 или AMD FX-8320", 201, 15, 102, "Windows 7/8.1/10 (64-разрядные версии)", 301, "The_Elder_Scrolls_V_Skyrim.png", 0, "NVIDIA GTX 780 (3 ГБ) AMD R9 290 (4 ГБ)", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Эта часть, как и предыдущие три игры серии — The Elder Scrolls II: Daggerfall, The Elder Scrolls III: Morrowind и The Elder Scrolls IV: Oblivion — получила титул «Игра года» на Video Game Award 2011. Действие происходит через 200 лет после событий Oblivion. Игра была анонсирована 11 ноября 2010 года, а выпущена 11 ноября 2011 года. В игре задействован новый движок Creation Engine и обновлённая система мелких квестов Radiant Story.", "Для одного игрока", "JSRtYpNRoN0", "The Elder Scrolls V: Skyrim", 50, new DateTime(2016, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skyrim_1.png", "Skyrim_2.png", "Skyrim_3.png", "Skyrim_4.png" },
                    { 410, "Intel Core i5-2300 2,8 ГГц/AMD Phenom II X4 945 3 ГГц", 201, 60, 103, "Windows 7/8/10/11 (необходима 64-битная ОС)", 301, "Fallout4.png", 8, "NVIDIA GTX 550 Ti 2 Гб/AMD Radeon HD 7870 2 Гб", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Добро пожаловать в игру нового поколения с открытым миром! Вы — единственный выживший из убежища 111, оказавшийся в мире, разрушенном ядерной войной. Каждый миг вы сражаетесь за выживание, каждое решение может стать последним. Но именно от вас зависит судьба пустошей. Добро пожаловать домой.", "Для одного игрока", "ErgtR14-MV8", "Fallout 4", 50, new DateTime(2015, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "fallout4_1.png", "fallout4_2.png", "fallout4_3.png", "fallout4_4.png" },
                    { 407, "Intel Core i7 3770 с частотой 3,4 ГГц / AMD FX-8350 с частотой 4 ГГц", 214, 77, 103, "64-разрядная Windows 7, 64-разрядная Windows 8 (8.1) или 64-разрядная Windows 10", 301, "Witcher3.png", 8, "NVIDIA GPU GeForce GTX 770 / AMD GPU Radeon R9 290", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Станьте профессиональным убийцей монстров и отправляйтесь в приключение эпических масштабов! После своего выхода игра «Ведьмак 3: Дикая Охота» (The Witcher 3: Wild Hunt) стала настоящей классикой, получив более 250 наград в номинации «Игра года». Вас ждёт более 100 часов грандиозного приключения по открытому миру, а также сюжетные расширения, которые растянутся ещё на 50 часов игры. Это издание включает в себя весь дополнительный контент: новое оружие, броню, экипировку для компаньонов, новый режим игры и побочные квесты.", "Для одного игрока", "4ndIeNusRLI", "Ведьмак 3: Дикая Охота", 50, new DateTime(2014, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "witcher3__screenshot_1.png", "witcher3__screenshot_2.png", "witcher3__screenshot_3.png", "witcher3__screenshot_4.png" },
                    { 405, "Intel Core i5-6600K", 201, 60, 103, "Windows 7/8/8.1/10", 301, "Fallout76.png", 8, "NVIDIA GeForce GTX 780", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "События игры происходят в 2102 году в Западной Виргинии. Игрок — житель Убежища 76 (Резидент), проспавший выход на поверхность. Находя голозаписи Смотрительницы Убежища, которая покинула его раньше всех, игрок понимает, что над регионом нависла опасность в виде горелых — людей, заражённых инфекцией, превращающихся со временем в неподвижные статуи, которые, распадаясь, разносят заразу, заражая как и других существ, так и людей. Как выясняется, источник той болезни — зверожоги. Это мутировавшие драконоподобные летучие мыши, обитавшие под землёй. По мере продвижения по сюжету и выполнению квестов игрок создаёт вакцину против чумы зверожогов. Далее Резиденту предстоит проникнуть в хорошо спрятанный бункер «Анклава» — бывшего правительства США. Там ему встречается МОДУС — суперкомпьютер, который убил всех членов Анклава в качестве мести за попытку уничтожить его. МОДУС рассказывает о ядерных ракетах и как их запустить. Игрок завладевает кодами запуска и, проведя бомбардировку главного разлома, откуда вылезают зверожоги, сталкивается с ещё более страшной угрозой — маткой зверожогов. В тяжёлом бою её удаётся убить, и зверожоги, оставшись без главы, разлетаются подобно муравьям, оставшимся без королевы.", "Для нескольких игроков", "EtiVOmFiWA0", "Fallout 76", 70, new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout76Screenshot_1.png", "Fallout76Screenshot_2.png", "Fallout76Screenshot_3.png", "Fallout76Screenshot_4.png" },
                    { 403, "2.6 GHz Quad Core or similar", 215, 2, 103, "Windows 7 64 bit", 301, "Valheim.png", 8, "GeForce GTX 950 or Radeon HD 7970", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вальхейм — это игра, в которой вам предстоит исследовать огромный фэнтезийный мир, пропитанный скандинавской мифологией и культурой викингов. Ваше приключение начнется в самом сердце Вальхейма, месте довольно спокойном. Но берегитесь, ведь чем дальше вы будете продвигаться, тем опаснее будет становиться мир вокруг. К счастью, по пути вас будут ждать не только опасности — вы также будете чаще находить ценные материалы, которые весьма пригодятся для создания смертоносного оружия и крепкой брони. Возводите крепости и заставы по всему миру! А со временем постройте несокрушимый драккар и отправьтесь покорять бескрайние океаны в поиске чужестранных земель... Но постарайтесь не заплыть слишком далеко...", "Для нескольких игроков", "5mHRJ1KFe20", "Valheim", 25, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valheim_screenshotGame_1.png", "Valheim_screenshotGame_2.png", "Valheim_screenshotGame_3.png", "Valheim_screenshotGame_4.png" },
                    { 408, "Intel® Core™ i7-4770K / AMD Ryzen 5 1500x", 205, 150, 101, "Windows 10 - April 2018 Update (v1803)", 304, "rdr2.png", 12, "Nvidia GeForce GTX 1060 6 ГБ / AMD Radeon RX 480 4 ГБ", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Америка, 1899 год. Артур Морган и другие подручные Датча ван дер Линде вынуждены пуститься в бега. Их банде предстоит участвовать в кражах, грабежах и перестрелках в самом сердце Америки. За ними по пятам идут федеральные агенты и лучшие в стране охотники за головами, а саму банду разрывают внутренние противоречия. Артуру предстоит выбрать, что для него важнее: его собственные идеалы или же верность людям, которые его взрастили.", "Для одного игрока / Для нескольких игроков", "0kqEBOZaP94", "Red Dead Redemption 2", 80, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "RDR2_screenshot_1.png", "RDR2_screenshot_2.png", "RDR2_screenshot_3.png", "RDR2_screenshot_4.png" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "701", "601" },
                    { "702", "602" }
                });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "id", "AllGamesid", "UserId", "finalPrice" },
                values: new object[] { 801, 401, "702", 3 });

            migrationBuilder.InsertData(
                table: "GameKey",
                columns: new[] { "id", "AllGamesid", "Key_game" },
                values: new object[,]
                {
                    { 909, 409, "CXBNWJHE-KFJHDHJWFEK-HWEJRF-WHKFEUJ" },
                    { 904, 404, "FJNVCDKM-KLWDEIRU-SXJNHWEG-SAJKFHJD" },
                    { 913, 413, "WIUETYR-AKFHGEW-HBJWRE-WRKQEJH" },
                    { 912, 412, "GYWUI-WBKFEJ-REYUWI-BHSAJ-URYIWQE" },
                    { 906, 406, "RTIOSDBN-REHJNMSAX-REUYBSXN-DSHJVBWE" },
                    { 908, 408, "VFBNYTWE-DSHJWQVB-DISUQWVB-KSJAEWBV" },
                    { 902, 402, "IEUWYHDB-DKSNZMEU-XHSKDMWO-XMBADHNR" },
                    { 914, 414, "WHEFJK-EWRBKJH-UIWYRQE-CBXZJHSD-EFWUIY" },
                    { 911, 411, "FWGYURQ-FEBVWQUY-QJHFG-QYUWEBN" },
                    { 907, 407, "REYUCBXN-YUEWVSBA-SAHJWVBQ-OXZIQVWB" },
                    { 905, 405, "GRHUSDNM-CXJNWGVD-DJNCLKWD-WEYUXZBN" },
                    { 903, 403, "ZXNEYTAB-KFBSYDBF-XHSNWDAC-DNWHDDEWE" },
                    { 901, 401, "GHZNAZXB-ZXNHDANX-IOEJZNDG-MSHSJWUJ" },
                    { 910, 410, "WFOQEUIFHW-KWEFHJ-BEWFJH-WEFVHGJ" },
                    { 915, 415, "RVUIEHG-0EFWIUY-WEHKFUJ-JKDSIJFSDO" }
                });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "id", "AllGamesid", "discountPrice", "nameImageSlider" },
                values: new object[,]
                {
                    { 504, 407, 30, "Wicher3.png" },
                    { 503, 408, 70, "rdr2.png" },
                    { 502, 405, 55, "Fallout76.png" },
                    { 501, 401, 30, "2077.png" }
                });

            migrationBuilder.InsertData(
                table: "Chek",
                columns: new[] { "id", "GameKeyid", "UserId", "dateAddedCheque", "nameGame", "priceGame" },
                values: new object[] { 1001, 901, "702", new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077", 24 });

            migrationBuilder.CreateIndex(
                name: "IX_AllGames_Developersid",
                table: "AllGames",
                column: "Developersid");

            migrationBuilder.CreateIndex(
                name: "IX_AllGames_Ganresid",
                table: "AllGames",
                column: "Ganresid");

            migrationBuilder.CreateIndex(
                name: "IX_AllGames_Platformsid",
                table: "AllGames",
                column: "Platformsid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_AllGamesid",
                table: "Basket",
                column: "AllGamesid");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserId",
                table: "Basket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chek_GameKeyid",
                table: "Chek",
                column: "GameKeyid");

            migrationBuilder.CreateIndex(
                name: "IX_Chek_UserId",
                table: "Chek",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameKey_AllGamesid",
                table: "GameKey",
                column: "AllGamesid");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_AllGamesid",
                table: "Shares",
                column: "AllGamesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Chek");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GameKey");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AllGames");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Ganres");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
