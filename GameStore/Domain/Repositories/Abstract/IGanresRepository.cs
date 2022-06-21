using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IGanresRepository
    {
        IQueryable<Ganres> GetGanres();
        Ganres GetGanresByid(int id);
        Ganres GetGanresByCodeWord(string nameGanres);
        void SaveGanres(Ganres entity);
        void DeleteGanres(int id);
    }
}
