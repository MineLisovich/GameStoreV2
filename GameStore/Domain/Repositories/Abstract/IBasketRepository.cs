using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;


namespace GameStore.Domain.Repositories.Abstract
{
    public interface IBasketRepository
    {
        IQueryable<Basket> GetBasket();
        Basket GetBasketByid(int id);
        void SaveBasket(Basket entity);
        void DeleteBasket(int id);
    }
}
