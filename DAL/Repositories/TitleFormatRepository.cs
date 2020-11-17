using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class TitleFormatRepository : GenericRepository<TitleFormats>
    {
        public TitleFormatRepository(Context context) : base(context)
        {

        }

        public async Task<List<TitleFormats>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleFormats>().Where(titleFormat => titleFormat.TitleId == id).ToListAsync();
        }
    }
}
