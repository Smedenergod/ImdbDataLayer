using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.Objects;
using IMDBDataService.Repositories;

namespace IMDBDataService
{
    public class DataService : IDataService
    {
        public static ImdbContext Context = new ImdbContext();
        //public UserRepository UserRepository = new UserRepository(context);
        //public TitleRepository TitleRepository = new TitleRepository(context);
        private readonly UserRepository _userRepository;
        private readonly IGenericRepository<Titles> _titleRepository;
        private readonly CommentsRepository _commentRepository;
        private readonly IGenericRepository<Bookmarks> _bookmarkRepository;
        private readonly IGenericRepository<SpecialRoles> _specialrolesRepository;
        private readonly IGenericRepository<UserRating> _userratingRepository;
        private readonly IGenericRepository<SearchHistory> _searchHistoryRepository;

        public DataService()
        {
            this._userRepository = new UserRepository(Context);
            this._titleRepository = new GenericRepository<Titles>(Context);
            this._commentRepository = new CommentsRepository(Context);
            this._bookmarkRepository = new GenericRepository<Bookmarks>(Context);
            this._specialrolesRepository = new GenericRepository<SpecialRoles>(Context);
            this._userratingRepository = new GenericRepository<UserRating>(Context);
            this._searchHistoryRepository = new GenericRepository<SearchHistory>(Context);
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
            await _searchHistoryRepository.ReadAll();
            return await _userRepository.ReadById(id);
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return await _userRepository.ReadByEmail(email);
        }

        public async Task<Users> ValidatePassword(string email, string password)
        {
            return await _userRepository.ValidatePassword(email, password);
        }

        public async Task<List<Titles>> GetAllTitles()
        {
            return await _titleRepository.ReadAll();
        }

        public async Task<Titles> GetTitleById(object id, int? user_id = null)
        {
            if (user_id != null)
            {
                await _commentRepository.WhereByUserId(user_id);
            }
            else
            {
                await _commentRepository.ReadAll();
            }
            //TODO:: same as commentRepository so we can return only relevant data to the logged in user
            await _userratingRepository.ReadAll();
            await _bookmarkRepository.ReadAll();
            return await _titleRepository.ReadById(id);
        }
        //TODO:: maybe use the db functions for comments here
        public async Task<Comments> CreateComment(Comments comment)
        {
            comment.comment_time = DateTime.Now;
            return await _commentRepository.Create(comment);
        }

        public async Task<Comments> UpdateComment(int id, Comments comment)
        {
            var Comment = await _commentRepository.ReadById(id);
            Comment.comment= comment.comment;
            Comment.comment_time = DateTime.Now;
            return await _commentRepository.Update(Comment);
        }

        public async Task<Comments> DeleteComment(int id)
        {
            return await _commentRepository.Delete(await _commentRepository.ReadById(id));
        }

        public async Task<Bookmarks> CreateBookmark(Bookmarks bookmark)
        {
            return await _bookmarkRepository.Create(bookmark);
        }

        public async Task<Bookmarks> DeleteBookmark(int id)
        {
            return await _bookmarkRepository.Delete(await _bookmarkRepository.ReadById(id));
        }

        public async Task<UserRating> RateTitle(UserRating userRating)
        {
            return await _userratingRepository.Create(userRating);
        }

        public async Task<Users> CreateUser(Users user)
        {
            user.last_access = DateTime.Now;
            user.account_creation = DateTime.Now;
            //Users newUser = new Users
            //{
            //    nickname = nickname, 
            //    user_name = name, 
            //    email = email, 
            //    derived_age = 9,
            //    user_pass = password,
            //    salt = "random", 
            //    date_of_birth = new DateTime(), 
            //    last_access = new DateTime(), 
            //    account_creation = new DateTime()
            //};
            return await _userRepository.Create(user);
        }

        public async Task<Users> DeleteUser(object id)
        {
            return await _userRepository.Delete(await _userRepository.ReadById(id));
        }

        public async Task<Users> UpdateUser(object id, Users user)
        {
            var User = await _userRepository.ReadById(id);
            User.user_name = user.user_name;
            User.user_pass= user.user_pass;
            User.salt = user.salt;
            User.date_of_birth = user.date_of_birth;
            User.email = user.email;
            User.nickname = user.nickname;
            return await _userRepository.Update(User);
        }

    }
}
