using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class TitleInfoRepository : GenericRepository<TitleInfo>
    {
        public TitleInfoRepository(Context context) : base(context)
        {

        }

        public async Task<List<TitleInfo>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleInfo>().Where(titleInfo => titleInfo.TitleId == id).ToListAsync();
        }
    }
}
