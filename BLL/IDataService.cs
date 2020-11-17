using System.Collections.Generic;
using System.Threading.Tasks;
using DataService.BLL.Filters;
using DataService.DAL.DMO;

namespace DataService.BLL
{
    public interface IDataService
    {
        //Cast
        public Task<Casts> GetCastById(string id, int ordering);
        public Task<CastInfo> GetCastInfoById(string id);
        public Task<List<Casts>> GetAllCasts(PaginationFilter paginationFilter = null);
        public Task<int> CountAll();
        public Task<List<CastInfo>> GetAllCastInfos();
        public Task<List<CastProfession>> GetCastProfessionByCastId(string id);
        public Task<List<CastKnownFor>> GetCastKnownForByCastId(string id);
        public Task<List<CastInfo>> GetCastInfoByCastId(string id);
        public Task<List<NameRating>> GetNameRatingByCastId(string id);
        public Task<List<NameRating>> UpdateNameRating(string id);
        public Task<List<Casts>> GetCastsByTitleId(string id);
        public Task<List<CastInfo>> SearchCastByName(string name);

        //User
        public Task<Users> GetUserById(object id);
        public Task<List<Users>> GetAllUsers();
        public Task<Users> CreateUser(Users entity);
        public Task<Users> UpdateUser(object id, Users entity);
        public Task<Users> DeleteUser(object id);
        public Task<Users> GetUserByEmail(string email);
        public Task<Users> ValidateUserByPassword(string email, string password);
        public Task<List<Comments>> GetCommentsByUserId(int id, PaginationFilter filter = null);
        public Task<Comments> GetCommentById(int id);
        public Task<Comments> DeleteComment(int id);
        public Task<List<UserRating>> GetUserRatingsByUserId(int id, PaginationFilter filter = null);
        public Task<Bookmarks> DeleteBookmark(int uid, string tid);
        public Task<List<Bookmarks>> GetBookmarksByUserId(int id, PaginationFilter filter = null);
        public Task<List<SpecialRoles>> GetSpecialRolesByUserId(int id);
        public Task<List<SpecialRoles>> DeleteSpecialRoleByUserId(int id);
        public Task<SpecialRoles> CreateSpecialRole(SpecialRoles entity);
        public Task<SpecialRoles> UpdateSpecialRole(SpecialRoles entity);
        public Task<List<SearchHistory>> GetSearchHistoryByUserId(int id, PaginationFilter filter = null);
        public Task<Comments> CreateComment(Comments entity);
        public Task<Comments> UpdateComment(int id, Comments comment);
        public Task<FlaggedComment> FlagComment(FlaggedComment comment);
        public Task<List<FlaggedComment>> GetFlaggedComment(int userId, int commentId);
        public Task<FlaggedComment> DeleteFlaggedComment(int userId, int commentId);
        public Task<UserRating> UpdateUserRating(UserRating entity);
        public Task<UserRating> DeleteUserRating(int userId, string titleId);

        //Title
        public Task<Titles> GetTitleById(object id);
        public Task<List<Titles>> GetAllTitles();
        public Task<List<Titles>> SearchForTitle(int? num, string searchString);
        public Task<UserRating> RateTitle(UserRating rating);
        public Task<List<Titles>> GetPopularTitles(int num, string type);
        public Task<List<Comments>> GetCommentsByTitleId(string id, PaginationFilter filter = null);
        public Task<List<TitleInfo>> GetTitleInfoByTitleId(string id);
        public Task<List<TitleAlias>> GetTitleAliasByTitleId(string id);
        public Task<List<TitleFormats>> GetTitleFormatByTitleId(string id);
        public Task<List<UserRating>> GetUserRatingByUserIdAndTitleId(int userId, string titleId, PaginationFilter filter = null);
        public Task<List<UserRating>> GetUserRatingByTitleId(string titleId, PaginationFilter filter = null);
        public Task<Bookmarks> CreateBookmark(Bookmarks entity);
        public Task<List<Bookmarks>> GetBookmark(string tid, int uid);
        public Task<Genres> GetGenreByTitleId(string id);
        public Task<List<Genres>> GetAllGenres();
        public Task<List<Formats>> GetAllFormats();
        public Task<Formats> GetFormatByTitleId(string id);
    }
}
