using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class FullCastData
    {
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public Person Directors { get; set; }
        public Person Writers { get; set; }
        public ActorShort Actors { get; set; }
        public Person Others { get; set; }
        public string ErrorMessage { get; set; }
    }
}
