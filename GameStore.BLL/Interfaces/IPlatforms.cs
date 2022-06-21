using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IPlatforms
    {
        void Make(PlatformsDTO platformsDTO);
        PlatformsDTO GetById(int? id);
        PlatformsDTO GetByName(string name);
        IEnumerable<PlatformsDTO> GetAll();
        void Dispose();
    }
}
