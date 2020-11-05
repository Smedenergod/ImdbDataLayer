using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class TitleFormats
    {
        public string title_id { get; set; }
        public int ordering { get; set; }
        public TitleAlias titleAlias { get; set; }
        public int format_id { get; set; }
        public Formats format { get; set; }
    }
}
