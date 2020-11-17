using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    public class NameRatingRepository : GenericRepository<NameRating>
    {
        public NameRatingRepository(Context context) : base(context)
        {

        }

        public async Task<List<NameRating>> WhereByCastId(string id)
        {
            return await Context.NameRatings.Where(nameRating => nameRating.CastId == id).ToListAsync();
        }

        public async Task<List<NameRating>> UpdateNameRating(string id)
        {
            await Context.Database.ExecuteSqlRawAsync("call name_rating({0})", id);
            return await WhereByCastId(id);
        }
    }
}
