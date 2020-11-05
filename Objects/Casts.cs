using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Casts
    {
        public string title_id { get; set; }
        public int ordering { get; set; }
        public string cast_id { get; set; }
        public string category { get; set; }
        public string? job { get; set; }
        public string? char_name { get; set; }

        public Titles title { get; set; }
        public CastInfo castInfo { get; set; }
    }
}
