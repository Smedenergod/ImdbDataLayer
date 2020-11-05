using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Bookmarks
    {
        public int user_id { get; set; }
        //public enum bookmark_type;
        public string type_id { get; set; }

        public Users User { get; set; }
        public Titles Title { get; set; }
    }
}
