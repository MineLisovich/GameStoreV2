using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IShares
    {
        void Make(SharesDTO sharesDTO);
        SharesDTO GetById(int? id);
        SharesDTO GetByName(string name);
        IEnumerable<SharesDTO> GetAll();
        void Dispose();
    }
}
