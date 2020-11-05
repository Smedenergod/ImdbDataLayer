using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Episodes
    {
        public string episode_id { get; set; }
        public string series_id { get; set; }
        public int? season_num { get; set; }
        public int? episode_num { get; set; }

        public Titles episode { get; set; }
        public Titles series { get; set; }
    }
}
