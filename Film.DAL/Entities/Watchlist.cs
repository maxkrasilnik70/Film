using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.Entities
{
    public class Watchlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FilmId { get; set; }
        public List<LastView> LastViews { get; set; }
    }
}
