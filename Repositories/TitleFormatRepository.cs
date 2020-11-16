using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class TitleFormatRepository : GenericRepository<TitleFormats>
    {
        public TitleFormatRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleFormats>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleFormats>().Where(titleFormat => titleFormat.TitleId == id).ToListAsync();
        }
    }
}
