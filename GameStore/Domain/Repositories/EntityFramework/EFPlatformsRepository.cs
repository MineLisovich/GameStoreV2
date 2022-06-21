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
    public class EFPlatformsRepository : IPlatformsRepository
    {
        private readonly AppDbContext context;
        public EFPlatformsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Platforms> GetPlatforms()
        {
            return context.Platforms;
        }
        public Platforms GetPlatformsByid(int id)
        {
            return context.Platforms.FirstOrDefault(x => x.id == id);
        }

        public Platforms GetPlatformsByCodeWord(string namePlatform)
        {
            return context.Platforms.FirstOrDefault(x => x.namePlatform == namePlatform);
        }

        public void SavePlatforms(Platforms entity)
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

        public void DeletePlatforms(int id)
        {
            context.Platforms.Remove(new Platforms() { id = id });
            context.SaveChanges();
        }
    }
}
