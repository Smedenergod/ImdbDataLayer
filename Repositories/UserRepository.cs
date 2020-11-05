using System;
using System.Collections.Generic;
using System.Text;
using IMDBDataService.Objects;

namespace IMDBDataService.Repositories
{
    public class UserRepository : GenericRepository<Users>
    {
        public UserRepository(ImdbContext context) : base(context)
        {

        }

    }
}
