using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Genres
    {
        public int genre_id { get; set; }
        public string genre { get; set; }

        public virtual ICollection<TitleGenres> TitleGenres
        {
            get;
            set;
        }
    }
}
