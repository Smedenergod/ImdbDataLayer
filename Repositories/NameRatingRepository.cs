using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    public class NameRatingRepository : GenericRepository<NameRating>
    {
        public NameRatingRepository(ImdbContext context) : base(context)
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
