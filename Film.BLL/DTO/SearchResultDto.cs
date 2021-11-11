using System;
using System.Collections.Generic;
using System.Text;

namespace Film.BLL.DTO
{
    public class SearchResultDto
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
