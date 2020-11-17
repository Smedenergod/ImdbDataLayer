using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class CastInfoRepository : GenericRepository<CastInfo>
    {
        public CastInfoRepository(Context context) : base(context)
        {

        }

        public async Task<List<CastInfo>> SearchByName(string name)
        {
            return await Context.Set<CastInfo>().Where(casts => casts.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<List<CastInfo>> WhereByCastId(string id)
        {
            return await Context.CastInfo.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
