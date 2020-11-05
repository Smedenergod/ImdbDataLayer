using System;
using System.Collections.Generic;
using System.Text;
using IMDBDataService.Objects;

namespace IMDBDataService.Repositories
{
    public class TitleRepository : GenericRepository<Titles>
    {
        public TitleRepository(ImdbContext context) : base(context)
        {

        }
    }
}
