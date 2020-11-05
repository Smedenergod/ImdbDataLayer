using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Titles
    {
        public string title_id { get; set; }
        public string title_type { get; set; }
        public string primary_title { get; set; }
        public string original_title { get; set; }
        public bool is_adult { get; set; }
        public int? runtime_mins { get; set; }
        public string? poster { get; set; }
        public string? start_year { get; set; }
        public string? year_end { get; set; }

        public virtual ICollection<TitleInfo> TitleInfo { get; set;}
        public virtual ICollection<TitleAlias> TitleAlias { get; set;}
        public virtual ICollection<TitleGenres> TitleGenre { get; set; }

        public virtual ICollection<Casts> Casts { get; set; }

        public virtual ICollection<Episodes> Episodes { get; set; }

        public virtual ICollection<Episodes> Seasons { get; set; }

        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual ICollection<Bookmarks> Bookmarks { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

    }
}
