using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using IMDBDataService.Filters;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class SearchHistoryRepository : GenericRepository<SearchHistory>
    {
        public SearchHistoryRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<SearchHistory>> WhereByUserId(int? id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<SearchHistory>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(searchHistory => searchHistory.UserId == id).ToListAsync();
            }
            return await Context.Set<SearchHistory>().Where(searchHistory => searchHistory.UserId == id).ToListAsync();
        }
    }
}
