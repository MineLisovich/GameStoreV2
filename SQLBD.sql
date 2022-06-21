create database GameStore_DB
ALTER DATABASE GameStore_DB
COLLATE Cyrillic_General_CI_AS ;
use GameStore_DB


/* ОБЛАСТЬ ВСПОМОГАТЕЛЬНЫЕ ТАБЛИЦЫ*/
/*СОЗДАНИЕ ТАБЛИЦ*/
create table Ganres (
	id smallint IDENTITY(0,1) PRIMARY KEY not null,
	nameGanres char(20) not null
)
insert into Ganres (nameGanres) values ('Экшн')
insert into Ganres (nameGanres) values ('Приключения')
insert into Ganres (nameGanres) values ('RPG')
insert into Ganres (nameGanres) values ('Симуляторы')
insert into Ganres (nameGanres) values ('Спорт')
insert into Ganres (nameGanres) values ('Гонки')
insert into Ganres (nameGanres) values ('Казуал')
select * from Ganres

create table Developers (
	id smallint IDENTITY(0,1) PRIMARY KEY not null,
	nameDeveloper char(20) not null
)
insert into Developers (nameDeveloper) values ('Bethesda')
insert into Developers (nameDeveloper) values ('Blizzard')
insert into Developers (nameDeveloper) values ('Valve')
insert into Developers (nameDeveloper) values ('Electronic Arts')
insert into Developers (nameDeveloper) values ('RockStar Games')
insert into Developers (nameDeveloper) values ('Ubisoft')
insert into Developers (nameDeveloper) values ('Square Enix')
insert into Developers (nameDeveloper) values ('Activision')
insert into Developers (nameDeveloper) values ('Konami')
insert into Developers (nameDeveloper) values ('2K Games')
insert into Developers (nameDeveloper) values ('Matrix Games')
insert into Developers (nameDeveloper) values ('Nacon')
insert into Developers (nameDeveloper) values ('Majesco')
insert into Developers (nameDeveloper) values ('CD Projekt Red')
insert into Developers (nameDeveloper) values ('Iron Gate AB')
select * from Developers

create table Platforms (
	id smallint IDENTITY(0,1) PRIMARY KEY not null,
	namePlatform char(20) not null
)
insert into Platforms (namePlatform) values ('Steam')
insert into Platforms (namePlatform) values ('Origin')
insert into Platforms (namePlatform) values ('Battle.net')
insert into Platforms (namePlatform) values ('RockStar Launcher')
insert into Platforms (namePlatform) values ('Epic Games Launcher')
insert into Platforms (namePlatform) values ('Ubisoft Connect')
select * from Platforms

create table RoleU(
id smallint IDENTITY(0,1) PRIMARY KEY not null,
nameRole char(6) not null
)
 insert into RoleU (nameRole) values ('ADMIN')
 insert into RoleU (nameRole) values ('USER')

 select * from RoleU
create table Users (
	id smallint IDENTITY(0,1) PRIMARY KEY not null,
	email char(30) not null,
	nickname char(50) not null,
	passwordU char(30) not null,
	roleU_FK smallint not null
	constraint FK_RoleU foreign key (roleU_FK) references RoleU (id)
)

insert into Users (email,nickname,passwordU,roleU_FK) values ('deeLimpay@mai.ru','deeLimpay','dee123',0)
insert into Users (email,nickname,passwordU,roleU_FK) values ('stepa@gmail.com','Stepashka','123',1)
select * from Users
/*КОНКЕЦ ОБЛАСТИ ВСПОМОГАТЕЛЬНЫХ ТАБЛИЦ*/

/*ОБЛАСТЬ ОСНАВНЫЕ ТАБЛИЦЫ*/

create table AllGames(
	id smallint IDENTITY(0,1) PRIMARY KEY not null,
	nameGame char(30) not null,
	ganres_FK smallint not null,
	descriptionG text not null, 
	releaseDate date not null,
	developers_FK smallint not null,
	price smallint not null,
	amount tinyint not null,
	poster char(40) not null,
	dateAddedSite date not null,
	platforms_FK smallint not null,
	constraint FK_Ganres foreign key (ganres_FK) references Ganres(id),
	constraint FK_Developers foreign key (developers_FK) references Developers(id),
	constraint FK_Platforms foreign key (platforms_FK) references Platforms(id)
)

insert into AllGames (nameGame,ganres_FK,descriptionG,releaseDate,developers_FK,price,amount,poster,dateAddedSite,platforms_FK)
values ('Cyberpunk 2077',2,' Cyberpunk 2077 — компьютерная игра в жанре экшен в открытом мире, разработанная и изданная польской студией CD Projekt. Действие игры происходит в 2077 году в Найт-Сити, вымышленном североамериканском городе из вселенной Cyberpunk.',
       '10.12.2020',13,34,20,'2077.png','02.04.2022',0)

insert into AllGames (nameGame,ganres_FK,descriptionG,releaseDate,developers_FK,price,amount,poster,dateAddedSite,platforms_FK)
values ('Grand Theft Auto V',0,' GTA V — компьютерная игра в жанре action-adventure с открытым миром, разработанная компанией Rockstar North и изданная компанией Rockstar Games.',
       '17.09.2013',4,20,20,'GTA5.png','02.04.2022',4)

insert into AllGames (nameGame,ganres_FK,descriptionG,releaseDate,developers_FK,price,amount,poster,dateAddedSite,platforms_FK)
values ('Valheim',3,' Valheim — компьютерная игра в жанре симулятора выживания в открытом мире, разрабатываемая шведской компанией Iron Gate и изданная компанией Coffee Stain.',
       '02.02.2021',14,12,10,'Valheim.png','02.04.2022',0)

insert into AllGames (nameGame,ganres_FK,descriptionG,releaseDate,developers_FK,price,amount,poster,dateAddedSite,platforms_FK)
values ('Assassin’s Creed',1,' Действие игры разворачивается во времена Третьего крестового похода, а именно в 1191 году. В настоящем времени бармена Дезмонда Майлса, главного героя, похищает корпорация «Абстерго», которая с помощью Анимуса, машины для извлечения генетической памяти, хочет найти артефакт Первой Цивилизации. В курс дела Дезмонда вводят учёный Уоррен Видик и его ассистентка Люси Стиллман. Они рассказывают ему, что он является потомком ассасина Альтаира ибн-Ла-Ахада, который обнаружил артефакт, и через него хотят узнать местонахождение артефакта.',
       '13.11.2007',5,13,25,'Assassin1.png','03.04.2022',0)


select * from Ganres
select * from Developers
select * from Platforms

create table Shares(
id smallint IDENTITY(0,1) PRIMARY KEY not null,
nameGame_FK smallint not null,
discountPrice smallint not null,
constraint FK_nameGame foreign key (nameGame_FK) references AllGames(id)
)

insert into Shares (nameGame_FK, discountPrice) values (2,5)

create table Basket(
id smallint IDENTITY(0,1) PRIMARY KEY not null,
nameGame_FK smallint not null,
users_FK smallint not null,
amount tinyint not null,
finalPrice smallint not null,
constraint FK_nameGameB foreign key (nameGame_FK) references AllGames(id),
constraint FK_usersB foreign key (users_FK) references Users(id)
)

drop table Basket

insert into Basket (nameGame_FK,users_FK,amount,finalPrice) values (2,1,1,5)
/*КОНЕЦ ОБЛАСТИ ОСНОВНЫХ ТАБЛИЦ*/

/*ОБЛАСТЬ СОЗДАНИЯ ОСНОВНЫХ ВЬЮШЕК*/
create view view_AllGames as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id

select * from view_AllGames

create view view_Sares as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, Shares.discountPrice, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from Shares join AllGames on Shares.nameGame_FK = AllGames.id  join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id

select * from view_Sares

create view view_Basket as
select AllGames.nameGame, AllGames.descriptionG, AllGames.releaseDate, AllGames.price, Users.nickname, Basket.amount, Basket.finalPrice
from Basket join AllGames on Basket.nameGame_FK = AllGames.id join Users on Basket.users_FK = Users.id

select * from view_Basket

create view view_Users as 
select Users.email, Users.nickname, Users.passwordU, RoleU.nameRole from Users
join RoleU on Users.roleU_FK = RoleU.id

select * from view_Users

/*КОНЕЦ ОБЛАСТИ СОЗДАНИЯ ОСНОВНЫХ ВЬЮШЕК*/
create view view_Actions as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'Экшн'

create view view_Adventures as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'Приключения'

create view view_RPG as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'RPG'

create view view_Simulators as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'Симуляторы'

create view view_Sport as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'Спорт'


create view view_Race as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'Гонки'

create view view_Casual as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
where Ganres.nameGanres = 'Казуал'

select * from view_Casual

create view view_NewGameOnTheSite as
select AllGames.nameGame, Ganres.nameGanres, AllGames.descriptionG, AllGames.releaseDate, Developers.nameDeveloper, AllGames.price, AllGames.poster, AllGames.dateAddedSite, Platforms.namePlatform
from AllGames join Ganres on AllGames.ganres_FK = Ganres.id join Developers on AllGames.developers_FK = Developers.id join Platforms on AllGames.platforms_FK = Platforms.id
order by AllGames.releaseDate 
offset 0 Rows

select * from view_NewGameOnTheSite
/* ОБЛАСТЬ СОЗДАНИЯ ВСПОМОГАТЕЛЬНЫХ ВЬЮШЕК СОЗДАНИЕ ВСПОМОГАТЕЛЬНЫХ ВЬЮШЕК*/
/*КОНЕЦ ОБЛАСТИ СОЗДАНИЯ ВСПОМОГАТЕЛЬНЫХ ВЬЮШЕК*/
