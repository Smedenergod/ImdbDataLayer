using System.Collections.Generic;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    public class TitleRepository : GenericRepository<Titles>
    {
        public TitleRepository(Context context) : base(context)
        {

        }

        public async Task<List<Titles>> SearchForTitle(int? num, string searchString)
        {
            return await Context.Titles.FromSqlRaw("SELECT * FROM best_match_search({0}, {1})", num, searchString).ToListAsync();
        }

        public async Task<List<Titles>> GetPopularTitles(int? num, string type)
        {
            return await Context.Titles.FromSqlRaw("SELECT * FROM popular_titles({0}, {1})", num, type).ToListAsync();
        }
    }
}
