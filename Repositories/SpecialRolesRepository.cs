using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    class SpecialRolesRepository : GenericRepository<SpecialRoles>
    {
        public SpecialRolesRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<SpecialRoles>> WhereByUserId(int? id)
        {
            return await Context.Set<SpecialRoles>().Where(specialRoles => specialRoles.UserId == id).ToListAsync();
        }
    }
}
