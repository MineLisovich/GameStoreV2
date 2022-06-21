using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GameStore.BLL.EntitiesDTO;
using GameStore.BLL.Infrastructure;
using GameStore.BLL.Interfaces;

using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;

namespace GameStore.BLL.Services
{
    public class AllGamesService : IAllGames
    {
        IUnitOfWork Database { get; set; }
        public AllGamesService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Make(AllGamesDTO allGamesDTO)
        {
            Ganres ganre = Database.Ganres.GetById(allGamesDTO.Ganresid);
            Platforms platforms = Database.Platforms.GetById(allGamesDTO.Platformsid);
            Developers developers = Database.Developers.GetById(allGamesDTO.Developersid);

            // валидация
            if (ganre == null)
                throw new ValidationException("Жанр не найден", "");
            if (platforms == null)
                throw new ValidationException("Платформа не найдена", "");
            if (developers == null)
                throw new ValidationException("Разработчик не найден", "");

            AllGames all = new AllGames
            {
                nameGame = allGamesDTO.nameGame,
                descriptionG = allGamesDTO.descriptionG,
                releaseDate = allGamesDTO.releaseDate,
                price = allGamesDTO.price,
                amount = allGamesDTO.amount,
                Poster = allGamesDTO.Poster,
                dateAddedSite = allGamesDTO.dateAddedSite,
                Ganresid = ganre.id,
                Platformsid = platforms.id,
                Developersid = developers.id
               
            };
            Database.AllGames.Create(all);
            Database.Save();
        }
        public IEnumerable<AllGamesDTO> GetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AllGames, AllGamesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AllGames>, List<AllGamesDTO>>(Database.AllGames.GetAll());
        }
        public AllGamesDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id игры", "");
            var allGames = Database.AllGames.GetById(id.Value);
            if (allGames == null)
                throw new ValidationException("Игра не найдена", "");

           
            return new AllGamesDTO 
            {
                id = allGames.id,
                nameGame = allGames.nameGame,
                descriptionG = allGames.descriptionG,
                releaseDate = allGames.releaseDate,
                price = allGames.price,
                amount = allGames.amount,
                Poster = allGames.Poster,
                dateAddedSite = allGames.dateAddedSite,
               
            };
        }
        public AllGamesDTO GetByName(string name)
        {
            if (name == null)
                throw new ValidationException("Не установлено имя игры", "");
            var allGames = Database.AllGames.GetByName(name);
            if (allGames == null)
                throw new ValidationException("Игра не найдена", "");


            return new AllGamesDTO
            {
                id = allGames.id,
                nameGame = allGames.nameGame,
                descriptionG = allGames.descriptionG,
                releaseDate = allGames.releaseDate,
                price = allGames.price,
                amount = allGames.amount,
                Poster = allGames.Poster,
                dateAddedSite = allGames.dateAddedSite,

            };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
