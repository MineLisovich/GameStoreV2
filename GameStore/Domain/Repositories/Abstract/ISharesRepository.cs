using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface ISharesRepository
    {
        IQueryable<Shares> GetShares();
        Shares GetSharesByid(int id);
       
        void SaveShares(Shares entity);
        void DeleteShares(int id);
    }
}
