using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class TitleGenreRepository : GenericRepository<TitleGenres>
    {
        public TitleGenreRepository(Context context) : base(context)
        {

        }

        public async Task<List<TitleGenres>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleGenres>().Where(titleGenre => titleGenre.TitleId == id).ToListAsync();
        }
    }
}
