using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class TitleAlias
    {
        public string title_id { get; set; }
        public Titles titles { get; set; }
        public int ordering { get; set; }
        public string title { get; set; }
        public string region { get; set; }
        public string language { get; set; }
        public string attributes { get; set; }
        public bool is_original_title { get; set; }

        public virtual ICollection<TitleFormats> TitleFormat { get; set; }
    }
}
