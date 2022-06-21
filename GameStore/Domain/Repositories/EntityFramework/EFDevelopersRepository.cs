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
    public class EFDevelopersRepository : IDevelopersRepository
    {
        private readonly AppDbContext context;
        public EFDevelopersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Developers> GetDevelopers()
        {
            return context.Developers;
        }

        public Developers GetDevelopersByid(int id)
        {
            return context.Developers.FirstOrDefault(x => x.id == id);
        }

        public Developers GetDevelopersByCodeWord(string nameDeveloper)
        {
            return context.Developers.FirstOrDefault(x => x.nameDeveloper == nameDeveloper);
        }
        public void SaveDevelopers(Developers entity)
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

        public void DeleteDevelopers(int id)
        {
            context.Developers.Remove(new Developers() { id = id });
            context.SaveChanges();
        }
    }
}
