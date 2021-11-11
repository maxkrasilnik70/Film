using Film.DAL.API_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.Interfaces
{
    public interface ICorezoidRepository
    {
        public List<CountGenres> GetCountGenres(List<string> filmTitles);
    }
}
