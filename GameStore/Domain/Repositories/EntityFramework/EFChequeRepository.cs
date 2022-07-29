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
    public class EFChequeRepository : IChequeRepository
    {
        private readonly AppDbContext context;
        public EFChequeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Cheque> GetCheque()
        {
            return context.Cheque;
        }
        public Cheque GetChequeByid(int id)
        {
            return context.Cheque.FirstOrDefault(x => x.id == id);
        }

        public void SaveCheque(Cheque entity)
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
        public void DeleteCheque(int id)
        {
            context.Cheque.Remove(new Cheque() { id = id });
            context.SaveChanges();
        }
    }
}
