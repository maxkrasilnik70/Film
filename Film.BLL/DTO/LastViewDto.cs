using System;
using System.Collections.Generic;
using System.Text;

namespace Film.BLL.DTO
{
    public class LastViewDto
    {
        public DateTime? View { get; set; }
        public int WatchlistId { get; set; }
    }
}
