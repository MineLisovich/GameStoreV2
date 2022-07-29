using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IChequeRepository
    {
        IQueryable<Cheque> GetCheque();
        Cheque GetChequeByid(int id);
        void SaveCheque(Cheque entity);
        void DeleteCheque(int id);
    }
}
