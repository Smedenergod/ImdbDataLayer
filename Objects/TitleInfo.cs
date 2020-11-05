using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class TitleInfo
    {
        public Titles titles { get; set; }
        public string title_id { get; set; }
        public string awards { get; set; }
        public string? plot { get; set; }
    }
}
