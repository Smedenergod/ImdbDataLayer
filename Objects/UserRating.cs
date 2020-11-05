using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class UserRating
    {
        public int user_id { get; set; }
        public string title_id { get; set; }
        public float score { get; set; }

        public Users User { get; set; }
        public Titles Title { get; set; }
    }
}
