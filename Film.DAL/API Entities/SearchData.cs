using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class SearchData
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }
        public List<SearchResult> Results { get; set; }
    }
}
