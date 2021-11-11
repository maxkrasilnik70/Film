using AutoMapper;
using Film.BLL.DTO;
using Film.BLL.Interfaces;
using Film.DAL.API_Entities;
using Film.DAL.Entities;
using Film.DAL.Interfaces;
using Film.DAL.Repositories;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Film.BLL.Services
{
    public class FilmService : IFilmService
    {
        private readonly IIMDbApiRepository _imdbRepository;
        private readonly IWatchlistRepository _watchlistRepository;
        private readonly ILastViewRepository _lastViewRepository;
        private readonly IMapper _mapper;
        private readonly ICorezoidApiRepository _corezoidRepository;

        public FilmService(IIMDbApiRepository imdbRepository, IWatchlistRepository watchlistRepository,
            ILastViewRepository lastViewRepository, IMapper mapper, ICorezoidApiRepository corezoidRepository)
        {
            _imdbRepository = imdbRepository;
            _watchlistRepository = watchlistRepository;
            _lastViewRepository = lastViewRepository;
            _mapper = mapper;
            _corezoidRepository = corezoidRepository;
        }

        public async Task<List<SearchResultDto>> GetFilmByNameAsync(string filmTitle)
        {
            var film = await _imdbRepository.GetFilmByNameAsync(filmTitle);
            var result = _mapper.Map<List<SearchResultDto>>(film);
            return result;
        }

        public async Task AddFilmToWatchlistAsync(WatchlistDto watchlistDto)
        {
            var watchlist = _mapper.Map<Watchlist>(watchlistDto);
            await _watchlistRepository.AddAsync(watchlist);
        }

        public async Task<List<SearchResultDto>> GetAllFilmsByUserIdAsync(int userId)
        {
            var films = await _watchlistRepository.GetByUserId(userId);

            var result = new List<SearchResultDto>();
            foreach (var film in films)
            {
                var filmsResponse = await _imdbRepository.GetAllFilmsByUserIdAsync(film.FilmId);
                result.AddRange(_mapper.Map<List<SearchResultDto>>(filmsResponse));
            }

            return result;
        }

        public async Task MakeFilmWatchedAsync(LastViewDto lastViewDto)
        {
            var lastView = _mapper.Map<LastView>(lastViewDto);
            await _lastViewRepository.AddAsync(lastView);
        }

        public async Task<TitleData> GetHighestRatedFilmAsync(int userId)
        {
            var watchlist = await _watchlistRepository.GetByUserId(userId);

            if (watchlist.Count <= 3)
                return null;

            var titleData = new List<TitleData>();
            foreach (var w in watchlist)
            {
                titleData.Add(await _imdbRepository.GetHighestRatedFilmAsync(w.FilmId));
            }

            int titleDataCount = titleData.Count;
            for (int i = 0; i < titleDataCount; i++)
            {
                var bestRating = titleData.Select(x => x.IMDbRating).Max();
                var bestFilm = titleData.Where(x => x.IMDbRating == bestRating).FirstOrDefault();

                var lastViews = watchlist.Where(x => x.FilmId == bestFilm.Id).Select(x => x.LastViews).FirstOrDefault();
                var quantityViews = lastViews.Where(m => DateTime.Now - m.View <= TimeSpan.FromDays(30)).Count();
                if (quantityViews < 2)
                {
                    return bestFilm;
                }

                titleData.Remove(bestFilm);
            }
            return null;
        }

        public List<CountGenresDto> GetCountGenres(List<string> filmTitles)
        {
            var countGenres = _corezoidRepository.GetCountGenres(filmTitles);
            return _mapper.Map<List<CountGenresDto>>(countGenres);
        }

    }
}
