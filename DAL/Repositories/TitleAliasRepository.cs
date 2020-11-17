using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class TitleAliasRepository : GenericRepository<TitleAlias>
    {
        public TitleAliasRepository(Context context) : base(context)
        {

        }

        public async Task<List<TitleAlias>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleAlias>().Where(titleAlias => titleAlias.TitleId == id).ToListAsync();
        }
    }
}
