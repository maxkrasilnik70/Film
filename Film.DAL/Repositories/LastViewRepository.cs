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
    public class LastViewRepository : ILastViewRepository
    {
        private readonly FilmContext _context;

        public LastViewRepository(FilmContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LastView lastView)
        {
            await _context.LastView.AddAsync(lastView);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LastView>> GetAll()
        {
            return await _context.LastView.ToListAsync();
        }

        public async Task<LastView> GetOne(int id)
        {
            return await _context.LastView.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(LastView lastView)
        {
            _context.LastView.Remove(lastView);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LastView lastView)
        {
            _context.Entry<LastView>(lastView).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
