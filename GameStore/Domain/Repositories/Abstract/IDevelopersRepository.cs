using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IDevelopersRepository
    {
        IQueryable<Developers> GetDevelopers();
        Developers GetDevelopersByid(int id);
        Developers GetDevelopersByCodeWord(string nameDeveloper);
        void SaveDevelopers(Developers entity);
        void DeleteDevelopers(int id);
    }
}
