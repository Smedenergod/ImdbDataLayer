using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class CastKnownForRepository : GenericRepository<CastKnownFor>
    {
        public CastKnownForRepository(Context context) : base(context)
        {

        }

        public async Task<List<CastKnownFor>> WhereByCastId(string id)
        {
            return await Context.CastKnownFor.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
