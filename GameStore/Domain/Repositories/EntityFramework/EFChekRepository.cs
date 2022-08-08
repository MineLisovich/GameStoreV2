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
    public class EFChekRepository : IChekRepository
    {
        private readonly AppDbContext context;
        public EFChekRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Chek> GetChek()
        {
            return context.Chek;
        }
        public Chek GetChekByid(int id)
        {
            return context.Chek.FirstOrDefault(x => x.id == id);
        }

        public void SaveChek(Chek entity)
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
        public void DeleteChek(int id)
        {
            context.Chek.Remove(new Chek() { id = id });
            context.SaveChanges();
        }
    }
}
