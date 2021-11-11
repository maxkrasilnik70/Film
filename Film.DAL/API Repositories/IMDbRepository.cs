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
    public class IMDbRepository : IIMDbRepository
    {
        public List<SearchResult> GetFilmByName(string filmTitle)
        {
            var client = new RestClient($"https://imdb-api.com/en/API/Search/k_ludnhyqz/{filmTitle}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var clientResponse = client.Execute(request);
            var result = JsonConvert.DeserializeObject<SearchData>(clientResponse.Content);

            return result.Results;
        }

        public List<SearchResult> GetAllFilmsByUserId(string filmId)
        {
            var result = new List<SearchResult>();

            var client = new RestClient($"https://imdb-api.com/en/API/Search/k_ludnhyqz/{filmId}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var clientResponse = client.Execute(request);
            var filmContent = JsonConvert.DeserializeObject<SearchData>(clientResponse.Content);

            result.AddRange(filmContent.Results);
            return result;
        }

        public TitleData GetHighestRatedFilm(string filmId)
        {
            var client = new RestClient($"https://imdb-api.com/en/API/Title/k_ludnhyqz/{filmId}/Posters,Wikipedia,");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var clientResponse = client.Execute(request);
            return JsonConvert.DeserializeObject<TitleData>(clientResponse.Content);
        }
    }
}
