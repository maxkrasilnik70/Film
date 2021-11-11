using Film.BLL.DTO;
using Film.DAL.API_Entities;
using Film.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Film.BLL.Interfaces
{
    public interface IFilmService
    {
        public Task<List<SearchResultDto>> GetFilmByNameAsync(string filmTitle);
        public Task AddFilmToWatchlistAsync(WatchlistDto watchlistDto);
        public Task<List<SearchResultDto>> GetAllFilmsByUserIdAsync(int userId);
        public Task MakeFilmWatchedAsync(LastViewDto lastViewDto);
        public Task<TitleData> GetHighestRatedFilmAsync(int userId);
        public List<CountGenresDto> GetCountGenres(List<string> filmTitles);
    }
}
