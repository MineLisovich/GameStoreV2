using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IDevelopers
    {
        void Make(DevelopersDTO developersDTO);
        DevelopersDTO GetById(int? id);
        DevelopersDTO GetByName(string name);
        IEnumerable<DevelopersDTO> GetAll();
        void Dispose();
    }
}
