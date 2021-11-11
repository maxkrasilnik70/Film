using Film.DAL.API_Entities;
using Film.DAL.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Repositories
{
    public class CorezoidApiRepository : ICorezoidApiRepository
    {
        public List<CountGenres> GetCountGenres(List<string> filmTitles)
        {
            return new List<CountGenres>();
        }
    }
}
