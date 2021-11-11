using Film.DAL.API_Entities;
using Film.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Film.DAL.Interfaces
{
    public interface IIMDbRepository
    {
        public List<SearchResult> GetFilmByName(string filmTitle);
        public List<SearchResult> GetAllFilmsByUserId(string filmId);
        public TitleData GetHighestRatedFilm(string filmId);
    }
}
