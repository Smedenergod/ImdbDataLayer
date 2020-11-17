using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.BLL.Filters;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    public class CommentsRepository : GenericRepository<Comments>
    {
        public CommentsRepository(Context context) : base(context)
        {

        }

        public async Task<List<Comments>> WhereByUserId(int? id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<Comments>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(comments => comments.UserId == id).ToListAsync();
            }
            return await Context.Set<Comments>().Where(comments => comments.UserId == id).ToListAsync();
        }

        public async Task<List<Comments>> WhereByTitleId(string id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<Comments>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(comments => comments.TitleId == id).ToListAsync();
            }
            return await Context.Set<Comments>().Where(comments => comments.TitleId == id).ToListAsync();
        }

    }
}
