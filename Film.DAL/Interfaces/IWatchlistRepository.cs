using Film.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Film.DAL.Interfaces
{
    public interface IWatchlistRepository
    {
        public Task AddAsync(Watchlist watchlist);
        public Task<Watchlist> GetOne(int id);
        public Task<List<Watchlist>> GetByUserId(int userId);
        public Task<List<Watchlist>> GetAll();
        public Task Remove(Watchlist watchlist);
        public Task Update(Watchlist watchlist);
    }
}
