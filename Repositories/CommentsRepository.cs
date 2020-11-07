using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDBDataService.Objects;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class CommentsRepository : GenericRepository<Comments>
    {
        public CommentsRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Comments>> WhereByUserId(int? id)
        {
            return await context.Set<Comments>().Where(comment => comment.user_id == id).ToListAsync();
        }
    }
}
