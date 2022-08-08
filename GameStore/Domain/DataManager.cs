using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Repositories.Abstract;

namespace GameStore.Domain
{
    public class DataManager
    {
        public IAllGamesRepository AllGames { get; set; }
        public IBasketRepository Basket { get; set; }   
        public IDevelopersRepository Developers { get; set; }
        public IGanresRepository Ganres { get; set; }   
        public IPlatformsRepository Platforms { get; set; }
        public ISharesRepository Shares { get; set; } 
        
        public IGameKeyRepository GameKey { get; set; }

        public IChekRepository Chek { get; set; }   
       // public IUsersRepository Users { get; set; }

        public DataManager (IAllGamesRepository AllGamesRepository, IBasketRepository BasketRepository, IDevelopersRepository DevelopersRepository,
            IGanresRepository GanresRepository, IPlatformsRepository PlatformsRepository, ISharesRepository SharesRepository, 
            IGameKeyRepository GameKeyRepository, IChekRepository ChequeRepository)
        {
            AllGames = AllGamesRepository;  
            Basket = BasketRepository;  
            Developers = DevelopersRepository;
            Ganres = GanresRepository;
            Platforms = PlatformsRepository;
            Shares = SharesRepository;
            GameKey = GameKeyRepository;
            Chek = ChequeRepository;  
           // Users = UsersRepository;

        }
    }
}
