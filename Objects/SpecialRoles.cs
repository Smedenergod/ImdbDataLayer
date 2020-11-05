using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBDataService.Objects
{
    public class SpecialRoles
    {
        public int user_id { get; set; }
        public string role_type { get; set; }

        public Users User { get; set; }
    }
}
