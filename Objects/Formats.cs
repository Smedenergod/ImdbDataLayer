using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Formats
    {
        public int format_id { get; set; }
        public string format { get; set; }

        public virtual ICollection<TitleFormats> TitleFormats { get; set; }
    }
}
