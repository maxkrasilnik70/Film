using Film.BLL.DTO;
using Film.BLL.Interfaces;
using Film.BLL.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Film.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet("filmName/{filmTitle}")]
        public async Task<List<SearchResultDto>> GetFilmByNameAsync(string filmTitle)
        {
            return await _filmService.GetFilmByNameAsync(filmTitle);
        }

        [HttpPost("addToWatchlist")]
        public Task AddFilmToWatchlistAsync(WatchlistDto watchlistDto)
        {
            return _filmService.AddFilmToWatchlistAsync(watchlistDto);
        }

        [HttpGet("allWatchlist/{userId}")]
        public async Task<List<SearchResultDto>> GetAllFilmsByUserIdAsync(int userId)
        {
            return await _filmService.GetAllFilmsByUserIdAsync(userId);
        }

        [HttpPost("filmWatched")]
        public Task MakeFilmWatchedAsync(LastViewDto lastViewDto)
        {
            return _filmService.MakeFilmWatchedAsync(lastViewDto);
        }

        [HttpPost("countGenres")]
        public List<CountGenresDto> GetCountGenres(List<string> filmTitles)
        {
            return _filmService.GetCountGenres(filmTitles);
        }
    }
}
