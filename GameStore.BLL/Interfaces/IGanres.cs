using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IGanres
    {
        void Make(GanresDTO ganresDTO);
        GanresDTO GetById(int? id);
        GanresDTO GetByName(string name);
        IEnumerable<GanresDTO> GetAll();
        void Dispose();
    }
}
