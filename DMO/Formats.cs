﻿using System.Collections.Generic;

namespace IMDBDataService.DMO
{
    public class Formats
    {
        public int FormatId { get; set; }
        public string Format { get; set; }
        public virtual ICollection<TitleFormats> TitleFormats { get; set; }
    }
}
