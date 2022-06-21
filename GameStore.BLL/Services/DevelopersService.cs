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
    public class DevelopersService : IDevelopers
    {
        IUnitOfWork Database { get; set; }
        public DevelopersService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Make(DevelopersDTO developersDTO)
        {
          

            Developers dev = new Developers
            {
              nameDeveloper = developersDTO.nameDeveloper

            };
            Database.Developers.Create(dev);
            Database.Save();
        }
        public IEnumerable<DevelopersDTO> GetAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Developers, DevelopersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Developers>, List<DevelopersDTO>>(Database.Developers.GetAll());
        }
        public DevelopersDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id разработчика", "");
            var dev = Database.Developers.GetById(id.Value);
            if (dev == null)
                throw new ValidationException("Разработчик не найден", "");


            return new DevelopersDTO { id = dev.id, nameDeveloper = dev.nameDeveloper };
        }
        public DevelopersDTO GetByName(string name)
        {
            if (name == null)
                throw new ValidationException("Не установлено имя разработчика", "");
            var dev = Database.Developers.GetByName(name);
            if (dev == null)
                throw new ValidationException("Разработчик не найдена", "");

            return new DevelopersDTO { id = dev.id, nameDeveloper = dev.nameDeveloper };

        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
