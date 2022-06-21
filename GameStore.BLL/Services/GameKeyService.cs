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
    public class GameKeyService : IGameKey
    {
        IUnitOfWork Database { get; set; }
        public GameKeyService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Make(GameKeyDTO gameKeyDTO)
        {
            AllGames allgames = Database.AllGames.GetById(gameKeyDTO.AllGamesid);
          

            // валидация
            if (allgames == null)
                throw new ValidationException("Игра не найдена", "");
          

            GameKey gamekey = new GameKey
            {
               AllGamesid = allgames.id,
               Key_game = gameKeyDTO.Key_game

            };
            Database.GameKey.Create(gamekey);
            Database.Save();
        }
        public IEnumerable<GameKeyDTO> GetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameKey, GameKeyDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GameKey>, List<GameKeyDTO>>(Database.GameKey.GetAll());
        }
        public GameKeyDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ключа от игры", "");
            var gamekey = Database.GameKey.GetById(id.Value);
            if (gamekey == null)
                throw new ValidationException("Ключ не найден", "");


            return new GameKeyDTO  { id = gamekey.id, Key_game = gamekey.Key_game };
        }
        public GameKeyDTO GetByName(string name)
        {
            if (name == null)
                throw new ValidationException("Не установлено ключ от игры", "");
            var gamekey = Database.GameKey.GetByName(name);
            if (gamekey == null)
                throw new ValidationException("Ключ не найден", "");
            return new GameKeyDTO { id = gamekey.id, Key_game = gamekey.Key_game };
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
