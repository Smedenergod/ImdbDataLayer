using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class CastsRepository : GenericRepository<Casts>
    {
        public CastsRepository(Context context) : base(context)
        {

        }

        public async Task<List<Casts>> WhereByTitleId(string id)
        {
            return await Context.Set<Casts>().Where(casts => casts.TitleId == id).ToListAsync();
        }
    }
}
