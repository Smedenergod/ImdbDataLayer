using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class Users
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public int? derived_age { get; set; }
        public string nickname { get; set; }
        public DateTime account_creation { get; set; }
        public DateTime last_access { get; set; }
        public string email { get; set; }
        public string user_pass { get; set; }
        public byte[] salt { get; set; }

        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual  ICollection<Bookmarks> Bookmarks { get; set; }
        public virtual  ICollection<Comments> Comments { get; set; }
        public virtual ICollection<SearchHistory> SearchHistories{ get; set; }
        public virtual ICollection<SpecialRoles> SpecialRoles { get; set; }
    }
}
