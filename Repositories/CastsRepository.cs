using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class CastsRepository : GenericRepository<Casts>
    {
        public CastsRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Casts>> WhereByTitleId(string id)
        {
            return await Context.Set<Casts>().Where(casts => casts.TitleId == id).ToListAsync();
        }
    }
}
