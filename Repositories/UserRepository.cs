using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IMDBDataService.Objects;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    public class UserRepository : GenericRepository<Users>
    {
        public UserRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<Users> ReadByEmail(string email)
        {
            return await context.Set<Users>().FirstAsync(user => user.email == email);
        }
        public async Task<Users> ValidatePassword(string email, string password)
        {
            return await context.Set<Users>().FirstAsync(user => user.email == email && user.user_pass == password);
        }
    }
}
