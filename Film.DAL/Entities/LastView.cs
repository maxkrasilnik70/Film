using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.Entities
{
    public class LastView
    {
        public int Id { get; set; }
        public DateTime? View { get; set; }
        public int WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }
    }
}
