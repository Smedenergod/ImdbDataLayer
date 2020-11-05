using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.Objects;
using IMDBDataService.Repositories;

namespace IMDBDataService
{
    public class DataService
    {
        public static ImdbContext Context = new ImdbContext();
        //public UserRepository UserRepository = new UserRepository(context);
        //public TitleRepository TitleRepository = new TitleRepository(context);
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IGenericRepository<Titles> _titleRepository;
        private readonly IGenericRepository<Comments> _commentRepository;
        private readonly IGenericRepository<Bookmarks> _bookmarkRepository;
        private readonly IGenericRepository<SpecialRoles> _specialrolesRepository;
        private readonly IGenericRepository<UserRating> _userratingRepository;

        public DataService()
        {
            this._userRepository = new GenericRepository<Users>(Context);
            this._titleRepository = new GenericRepository<Titles>(Context);
            this._commentRepository = new GenericRepository<Comments>(Context);
            this._bookmarkRepository = new GenericRepository<Bookmarks>(Context);
            this._specialrolesRepository = new GenericRepository<SpecialRoles>(Context);
            this._userratingRepository = new GenericRepository<UserRating>(Context);
        }


        public async Task<List<Users>> GetAllUsers()
        {
            //await _commentRepository.ReadAll();
            return await _userRepository.ReadAll();
        }

        public async Task<Users> GetUserById(object id)
        {
            await _commentRepository.ReadAll();
            await _bookmarkRepository.ReadAll();
            await _specialrolesRepository.ReadAll();
            await _userratingRepository.ReadAll();
            return await _userRepository.ReadById(id);
        }

        public async Task<List<Titles>> GetAllTitles()
        {
            return await _titleRepository.ReadAll();
        }

        public async Task<Titles> GetTitleById(object id)
        {
            return await _titleRepository.ReadById(id);
        }

        public async Task<Users> CreateUser(string name, string nickname, string email, string password)
        {
            Users newUser = new Users
            {
                nickname = nickname, 
                user_name = name, 
                email = email, 
                derived_age = 9,
                user_pass = password,
                salt = "random", 
                date_of_birth = new DateTime(), 
                last_access = new DateTime(), 
                account_creation = new DateTime()
            };
            return await _userRepository.Create(newUser);
        }

        public async Task<Users> DeleteUser(int id)
        {
            return await _userRepository.Delete(await _userRepository.ReadById(id));
        }

        public async Task<Users> UpdateUser(int id, string newName)
        {
            var User = await _userRepository.ReadById(id);
            User.user_name = newName;
            return await _userRepository.Update(User);
        }
    }
}
