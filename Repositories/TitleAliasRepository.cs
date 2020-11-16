﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class TitleAliasRepository : GenericRepository<TitleAlias>
    {
        public TitleAliasRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleAlias>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleAlias>().Where(titleAlias => titleAlias.TitleId == id).ToListAsync();
        }
    }
}
