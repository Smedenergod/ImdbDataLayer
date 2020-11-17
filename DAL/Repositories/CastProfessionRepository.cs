using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class CastProfessionRepository : GenericRepository<CastProfession>
    {
        public CastProfessionRepository(Context context) : base(context)
        {

        }

        public async Task<List<CastProfession>> WhereByCastId(string id)
        {
            return await Context.CastProfession.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
