﻿using System.Threading.Tasks;
using IMDBDataService.DMO;
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
            return await Context.Set<Users>().FirstAsync(user => user.Email == email);
        }
        public async Task<Users> ValidatePassword(string email, string password)
        {
            return await Context.Set<Users>().FirstAsync(user => user.Email == email && user.Password == password);
        }
    }
}
