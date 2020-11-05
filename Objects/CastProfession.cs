using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class CastProfession
    {
        public string cast_id { get; set; }
        public string profession { get; set; }

        public CastInfo castInfo { get; set; }
    }
}
