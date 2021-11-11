using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class BoxOfficeShort
    {
        public string Budget { get; set; }
        public string OpeningWeekendUSA { get; set; }
        public string GrossUSA { get; set; }
        public string CumulativeWorldwideGross { get; set; }
    }
}
