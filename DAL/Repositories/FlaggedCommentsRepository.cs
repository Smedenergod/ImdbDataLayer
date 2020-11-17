using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class FlaggedCommentsRepository : GenericRepository<FlaggedComment>
    {
        public FlaggedCommentsRepository(Context context) : base(context)
        {

        }
        
        public async Task<List<FlaggedComment>> WhereByUserIdAndCommentId(int userId, int commentId)
        {
            return await Context.FlaggedComments.Where(flaggedComments =>
                flaggedComments.CommentId == commentId && flaggedComments.FlaggingUser == userId).ToListAsync();
        }
    }
}
