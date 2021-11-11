using Film.DAL.API_Entities;
using Film.DAL.Entities;
using Film.DAL.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Film.DAL.API_Repositories
{
    public class IMDbApiRepository : IIMDbApiRepository
    {
        public async Task<List<SearchResult>> GetFilmByNameAsync(string filmTitle)
        {
            var client = new RestClient($"https://imdb-api.com/en/API/Search/k_ludnhyqz/{filmTitle}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var clientResponse = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<SearchData>(clientResponse.Content);
           
            return result.Results;
        }

        public async Task<List<SearchResult>> GetAllFilmsByUserIdAsync(string filmId)
        {
            var result = new List<SearchResult>();

            var client = new RestClient($"https://imdb-api.com/en/API/Search/k_ludnhyqz/{filmId}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var clientResponse = await client.ExecuteAsync(request);
            var filmContent = JsonConvert.DeserializeObject<SearchData>(clientResponse.Content);

            result.AddRange(filmContent.Results);
            return result;
        }

        public async Task<TitleData> GetHighestRatedFilmAsync(string filmId)
        {
            var client = new RestClient($"https://imdb-api.com/en/API/Title/k_ludnhyqz/{filmId}/Posters,Wikipedia,");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var clientResponse = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<TitleData>(clientResponse.Content);
        }
    }
}
