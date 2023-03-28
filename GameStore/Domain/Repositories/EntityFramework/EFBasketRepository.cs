using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Repositories.Abstract;

namespace GameStore.Domain.Repositories.EntityFramework
{
    public class EFBasketRepository: IBasketRepository
    {
        private readonly AppDbContext context;
        public EFBasketRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Basket> GetBasket()
        {
            return context.Basket.Include(g => g.AllGames).Include(u => u.User);
        }
        public Basket GetBasketByid(int id)
        {
            return context.Basket.FirstOrDefault(x => x.id == id);
        }

        public void SaveBasket(Basket entity)
        {
            if (entity.id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
                
            }
            context.SaveChanges();
        }
        public void DeleteBasket(int id)
        {
            context.Basket.Remove(new Basket() { id = id });
            context.SaveChanges();
        }
    }
}
