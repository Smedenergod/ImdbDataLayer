using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class CastInfo
    {
        public string cast_id { get; set; }
        public string name { get; set; }
        public string birth_year { get; set; }
        public string? death_year { get; set; }

        public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<CastProfession> CastProfession { get; set; }
        public virtual ICollection<CastKnownFor> CastKnownFor { get; set; }
    }
}
