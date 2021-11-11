using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class PosterDataItem
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public double AspectRatio { get; set; }
        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
