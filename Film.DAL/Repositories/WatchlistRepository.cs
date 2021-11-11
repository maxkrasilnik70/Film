using Film.DAL.Context;
using Film.DAL.Entities;
using Film.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.DAL.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly FilmContext _context;

        public WatchlistRepository(FilmContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Watchlist watchlist)
        {
            await _context.Watchlist.AddAsync(watchlist);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Watchlist>> GetAll()
        {
            return await _context.Watchlist.ToListAsync();
        }

        public async Task<List<Watchlist>> GetByUserId(int userId)
        {
            return await _context.Watchlist.Include(w => w.LastViews).Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task<Watchlist> GetOne(int id)
        {
            return await _context.Watchlist.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Watchlist watchlist)
        {
            _context.Watchlist.Remove(watchlist);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Watchlist watchlist)
        {
            _context.Entry<Watchlist>(watchlist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
