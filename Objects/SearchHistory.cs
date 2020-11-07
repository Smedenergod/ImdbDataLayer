using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class SearchHistory
    {
        public int UserId { get; set; }
        public int Ordering { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchString { get; set; }

        public Users User { get; set; }
    }
}
