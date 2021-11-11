using Film.DAL.API_Entities;
using Film.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Film.DAL.Interfaces
{
    public interface IIMDbApiRepository
    {
        public Task<List<SearchResult>> GetFilmByNameAsync(string filmTitle);
        public Task<List<SearchResult>> GetAllFilmsByUserIdAsync(string filmId);
        public Task<TitleData> GetHighestRatedFilmAsync(string filmId);
    }
}
