﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class WikipediaData
    {
        public string IMDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }

        public string Language { get; set; }
        public string TitleInLanguage { get; set; }
        public string Url { get; set; }

        public WikipediaDataPlot PlotShort { get; set; }
        public WikipediaDataPlot PlotFull { get; set; }

        public string ErrorMessage { get; set; }
    }
}
