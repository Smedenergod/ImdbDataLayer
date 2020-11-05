using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Comments
    {
        public int comment_id { get; set; }
        public DateTime comment_time { get; set; }
        public int user_id { get; set; }
        public string title_id { get; set; }
        public string comment { get; set; }

        public Users User { get; set; }
        public Titles Title { get; set; }
    }
}
