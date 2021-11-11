using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class PosterData
    {
        public string IMDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { set; get; }
        public string Year { set; get; }

        public List<PosterDataItem> Posters { get; set; }
        public List<PosterDataItem> Backdors { get; set; }

        public string ErrorMessage { get; set; }
    }
}
