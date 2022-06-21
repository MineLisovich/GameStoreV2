using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IPlatformsRepository
    {
        IQueryable<Platforms> GetPlatforms();
        Platforms GetPlatformsByid(int id);
        Platforms GetPlatformsByCodeWord(string namePlatform);
        void SavePlatforms(Platforms entity);
        void DeletePlatforms(int id);
    }
}
