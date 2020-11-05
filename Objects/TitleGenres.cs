using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class TitleGenres
    {
        public string title_id { get; set; }
        public Titles title { get; set; }
        public int genre_id { get; set; }
        public Genres genre { get; set; }
    }

}
