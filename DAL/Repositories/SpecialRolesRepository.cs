using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    class SpecialRolesRepository : GenericRepository<SpecialRoles>
    {
        public SpecialRolesRepository(Context context) : base(context)
        {

        }

        public async Task<List<SpecialRoles>> WhereByUserId(int? id)
        {
            return await Context.Set<SpecialRoles>().Where(specialRoles => specialRoles.UserId == id).ToListAsync();
        }
    }
}
