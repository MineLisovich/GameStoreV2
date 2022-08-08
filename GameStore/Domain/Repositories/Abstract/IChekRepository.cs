using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IChekRepository
    {
        IQueryable<Chek> GetChek();
        Chek GetChekByid(int id);
        void SaveChek(Chek entity);
        void DeleteChek(int id);
    }
}
