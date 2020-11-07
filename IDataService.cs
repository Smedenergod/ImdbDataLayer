using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IMDBDataService.Objects;

namespace IMDBDataService
{
    public interface IDataService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(object id);
        Task<Users> GetUserByEmail(string email);
        Task<Users> ValidatePassword(string email, string password);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(object id, Users user);
        Task<Users> DeleteUser(object id);
        Task<List<Titles>> GetAllTitles();
        Task<Titles> GetTitleById(object id, int? user_id);
        Task<Comments> CreateComment(Comments comment);
        Task<Comments> UpdateComment(int id, Comments comment);
        Task<Comments> DeleteComment(int id);
        Task<Bookmarks> CreateBookmark(Bookmarks bookmark);
        Task<Bookmarks> DeleteBookmark(int id);
        Task<UserRating> RateTitle(UserRating userRating);
    }
}
