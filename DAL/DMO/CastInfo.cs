﻿using System.Collections.Generic;

namespace DataService.DAL.DMO
{
    public class CastInfo
    {
        public string CastId { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<CastProfession> CastProfession { get; set; }
        public virtual ICollection<CastKnownFor> CastKnownFor { get; set; }
        public virtual ICollection<NameRating> NameRating { get; set; }
    }
}