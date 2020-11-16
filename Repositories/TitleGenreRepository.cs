using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class TitleGenreRepository : GenericRepository<TitleGenres>
    {
        public TitleGenreRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleGenres>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleGenres>().Where(titleGenre => titleGenre.TitleId == id).ToListAsync();
        }
    }
}
