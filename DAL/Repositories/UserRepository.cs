using System.Threading.Tasks;
using DataService.DAL.DMO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DAL.Repositories
{
    public class UserRepository : GenericRepository<Users>
    {
        public UserRepository(Context context) : base(context)
        {

        }

        public async Task<Users> ReadByEmail(string email)
        {
            return await Context.Set<Users>().FirstAsync(user => user.Email == email);
        }
        public async Task<Users> ValidatePassword(string email, string password)
        {
            return await Context.Set<Users>().FirstAsync(user => user.Email == email && user.Password == password);
        }
    }
}
