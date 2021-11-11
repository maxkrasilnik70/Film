using Film.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Film.DAL.Interfaces
{
    public interface ILastViewRepository
    {
        public Task AddAsync(LastView lastView);
        public Task<LastView> GetOne(int id);
        public Task<List<LastView>> GetAll();
        public Task Remove(LastView lastView);
        public Task Update(LastView lastView);
    }
}
