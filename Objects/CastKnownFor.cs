using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class CastKnownFor
    {
        public string cast_id { get; set; }
        public string known_for { get; set; }
        public CastInfo castInfo { get; set; }
    }
}
