using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class TitleInfoRepository : GenericRepository<TitleInfo>
    {
        public TitleInfoRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleInfo>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleInfo>().Where(titleInfo => titleInfo.TitleId == id).ToListAsync();
        }
    }
}
