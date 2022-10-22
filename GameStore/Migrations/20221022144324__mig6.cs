using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Migrations
{
    public partial class _mig6 : Migration
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
                    { "602", "f28918de-a195-442e-bc8b-cfa6c89a384a", "user", "USER" },
                    { "601", "07459139-df17-4d3d-81ea-9246435eee54", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "702", 0, "62a4edcc-4c40-4a17-992e-c158d4d5fa86", "stepa@gmail.com", true, false, null, "stepa@gmail.com", "Stepashka", "AQAAAAEAACcQAAAAELTLTwBLS9Dt74v22ksstJSLttCQMnWaSBcPmaRT1843impkq47kM3liLRwFcYpukg==", null, false, "", false, "Stepashka" },
                    { "701", 0, "22f2ad2c-3295-4a9f-b041-ed82d9dbaa57", "deeLimpay@mail.ru", true, false, null, "deeLimpay@mail.ru", "deeLimpay", "AQAAAAEAACcQAAAAEICMFd5qn1WJ6750PASuIdBPvafefYMtn8Ieuo/b3TcP8fv4y2CSFE1zATwwM0eNeQ==", null, false, "", false, "deeLimpay" }
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
                columns: new[] { "id", "CPU", "Developersid", "GameWeight", "Ganresid", "OS", "Platformsid", "Poster", "RAM", "VRAM", "dateAddedSite", "descriptionG", "linkTrailerGame", "nameGame", "price", "releaseDate", "screenshotGame_1", "screenshotGame_2", "screenshotGame_3", "screenshotGame_4" },
                values: new object[,]
                {
                    { 401, "Intel Core i5-11400F or AMD Ryzen 5 5600X", 201, 14, 101, "Windows 10 64 bit", 301, "2077.png", 8, "Nvidia GeForce GTX 1650 GP 4GB GDDR6", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), " Cyberpunk 2077 — компьютерная игра в жанре экшен в открытом мире, разработанная и изданная польской студией CD Projekt. Действие игры происходит в 2077 году в Найт-Сити, вымышленном североамериканском городе из вселенной Cyberpunk.", "aSrFWinrkeQ", "Cyberpunk 2077", 34, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk_screenshotGame_1.png", "Cyberpunk_screenshotGame_2.png", "Cyberpunk_screenshotGame_3.png", "Cyberpunk_screenshotGame_4.png" },
                    { 402, "Intel Core i5-11400F or AMD Ryzen 5 5600X", 201, 14, 101, "Windows 10 64 bit", 301, "GTA5.png", 8, "Nvidia GeForce GTX 1650 GP 4GB GDDR6", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTA V — компьютерная игра в жанре action-adventure с открытым миром, разработанная компанией Rockstar North и изданная компанией Rockstar Games.", "QkkoHAzjnUs", "Grand Theft Auto V", 25, new DateTime(2013, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTAV_screenshotGame_1.png", "GTAV_screenshotGame_2.png", "GTAV_screenshotGame_3.png", "GTAV_screenshotGame_4.png" },
                    { 403, "Intel Core i5-11400F or AMD Ryzen 5 5600X", 201, 14, 101, "Windows 10 64 bit", 301, "Valheim.png", 8, "Nvidia GeForce GTX 1650 GP 4GB GDDR6", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valheim — компьютерная игра в жанре симулятора выживания в открытом мире, разрабатываемая шведской компанией Iron Gate и изданная компанией Coffee Stain.", "5mHRJ1KFe20", "Valheim", 10, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valheim_screenshotGame_1.png", "Valheim_screenshotGame_2.png", "Valheim_screenshotGame_3.png", "Valheim_screenshotGame_4.png" },
                    { 404, "Intel Core i5-11400F or AMD Ryzen 5 5600X", 201, 14, 101, "Windows 10 64 bit", 301, "Assassin1.png", 8, "Nvidia GeForce GTX 1650 GP 4GB GDDR6", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Действие игры разворачивается во времена Третьего крестового похода, а именно в 1191 году. В настоящем времени бармена Дезмонда Майлса, главного героя, похищает корпорация «Абстерго», которая с помощью Анимуса, машины для извлечения генетической памяти, хочет найти артефакт Первой Цивилизации. В курс дела Дезмонда вводят учёный Уоррен Видик и его ассистентка Люси Стиллман. Они рассказывают ему, что он является потомком ассасина Альтаира ибн-Ла-Ахада, который обнаружил артефакт, и через него хотят узнать местонахождение артефакта.", "RjQ6ZtyXoA0", "Assassin’s Creed", 13, new DateTime(2007, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin1_screenshotGame_1.png", "Assassin1_screenshotGame_2.png", "Assassin1_screenshotGame_3.png", "Assassin1_screenshotGame_4.png" },
                    { 405, "Intel Core i5-11400F or AMD Ryzen 5 5600X", 201, 14, 101, "Windows 10 64 bit", 301, "Fallout76.png", 8, "Nvidia GeForce GTX 1650 GP 4GB GDDR6", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "События игры происходят в 2102 году в Западной Виргинии. Игрок — житель Убежища 76 (Резидент), проспавший выход на поверхность. Находя голозаписи Смотрительницы Убежища, которая покинула его раньше всех, игрок понимает, что над регионом нависла опасность в виде горелых — людей, заражённых инфекцией, превращающихся со временем в неподвижные статуи, которые, распадаясь, разносят заразу, заражая как и других существ, так и людей. Как выясняется, источник той болезни — зверожоги. Это мутировавшие драконоподобные летучие мыши, обитавшие под землёй. По мере продвижения по сюжету и выполнению квестов игрок создаёт вакцину против чумы зверожогов. Далее Резиденту предстоит проникнуть в хорошо спрятанный бункер «Анклава» — бывшего правительства США. Там ему встречается МОДУС — суперкомпьютер, который убил всех членов Анклава в качестве мести за попытку уничтожить его. МОДУС рассказывает о ядерных ракетах и как их запустить. Игрок завладевает кодами запуска и, проведя бомбардировку главного разлома, откуда вылезают зверожоги, сталкивается с ещё более страшной угрозой — маткой зверожогов. В тяжёлом бою её удаётся убить, и зверожоги, оставшись без главы, разлетаются подобно муравьям, оставшимся без королевы.", "RjQ6ZtyXoA0", "Fallout 76", 55, new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout76Screenshot_1.png", "Fallout76Screenshot_2.png", "Fallout76Screenshot_3.png", "Fallout76Screenshot_4.png" }
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
                values: new object[] { 901, 401, "XXXX-XXXX-XXXX" });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "id", "AllGamesid", "discountPrice", "nameImageSlider" },
                values: new object[] { 501, 401, 3, "name1.png" });

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
