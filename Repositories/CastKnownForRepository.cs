using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class CastKnownForRepository : GenericRepository<CastKnownFor>
    {
        public CastKnownForRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<CastKnownFor>> WhereByCastId(string id)
        {
            return await Context.CastKnownFor.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
