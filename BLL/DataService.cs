using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataService.BLL.Filters;
using DataService.DAL;
using DataService.DAL.DMO;
using DataService.DAL.Repositories;

namespace DataService.BLL
{
    class DataService
    {
        //Cast
        private readonly CastsRepository _casts;
        private readonly CastInfoRepository _castInfo;
        private readonly CastProfessionRepository _castProfession;
        private readonly CastKnownForRepository _castKnownFor;

        //Title
        private readonly TitleRepository _titles;
        private readonly TitleFormatRepository _titleFormat;
        private readonly TitleGenreRepository _titleGenre;
        private readonly TitleAliasRepository _titleAlias;
        private readonly TitleInfoRepository _titleInfo;
        private readonly GenreRepository _genre;
        private readonly FormatRepository _format;
        private readonly IGenericRepository<Episodes> _episodes;

        //User
        private readonly NameRatingRepository _nameRating;
        private readonly CommentsRepository _comments;
        private readonly BookmarkRepository _bookmarks;
        private readonly FlaggedCommentsRepository _flaggedComments;
        private readonly UserRepository _users;
        private readonly SpecialRolesRepository _specialRoles;
        private readonly SearchHistoryRepository _searchHistory;
        private readonly UserRatingRepository _userRatings;
        private readonly Context _context = new Context();
        private readonly IMapper _mapper;


        public DataService()
        {
            _mapper = new Mapper.Mapper().Config.CreateMapper();

            //Cast
            _casts = new CastsRepository(_context);
            _castInfo = new CastInfoRepository(_context);
            _castProfession = new CastProfessionRepository(_context);
            _castKnownFor = new CastKnownForRepository(_context);

            //Titles
            _titles = new TitleRepository(_context);
            _titleFormat = new TitleFormatRepository(_context);
            _titleGenre = new TitleGenreRepository(_context);
            _titleAlias = new TitleAliasRepository(_context);
            _titleInfo = new TitleInfoRepository(_context);
            _episodes = new GenericRepository<Episodes>(_context);
            _genre = new GenreRepository(_context);
            _format = new FormatRepository(_context);

            //User
            _users = new UserRepository(_context);
            _nameRating = new NameRatingRepository(_context);
            _comments = new CommentsRepository(_context);
            _bookmarks = new BookmarkRepository(_context);
            _flaggedComments = new FlaggedCommentsRepository(_context);
            _searchHistory = new SearchHistoryRepository(_context);
            _specialRoles = new SpecialRolesRepository(_context);
            _userRatings = new UserRatingRepository(_context);
        }


        //Cast
        public async Task<List<Casts>> GetAllCasts(PaginationFilter paginationFilter = null)
        {
            return await _casts.ReadAll(paginationFilter);
        }

        //TODO Rename this function
        public async Task<int> CountAll()
        {
            return await _casts.CountAll();
        }

        public async Task<List<CastInfo>> GetAllCastInfos()
        {
            return await _castInfo.ReadAll();
        }

        public async Task<List<CastProfession>> GetCastProfessionByCastId(string id)
        {
            return await _castProfession.WhereByCastId(id);
        }

        public async Task<List<CastKnownFor>> GetCastKnownForByCastId(string id)
        {
            return await _castKnownFor.WhereByCastId(id);
        }

        public async Task<List<CastInfo>> GetCastInfoByCastId(string id)
        {
            return await _castInfo.WhereByCastId(id);
        }

        public async Task<List<NameRating>> GetNameRatingByCastId(string id)
        {
            return await _nameRating.WhereByCastId(id);
        }

        public async Task<List<NameRating>> UpdateNameRating(string id)
        {
            return await _nameRating.UpdateNameRating(id);
        }

        public async Task<Casts> GetCastById(string id, int ordering)
        {
            return await _casts.ReadById(new object[] { id, ordering });
        }

        public async Task<CastInfo> GetCastInfoById(string id)
        {
            return await _castInfo.ReadById(id);
        }

        public async Task<List<Casts>> GetCastsByTitleId(string id)
        {
            return await _casts.WhereByTitleId(id);
        }

        public async Task<List<CastInfo>> SearchCastByName(string name)
        {
            return await _castInfo.SearchByName(name);
        }

        //Title

        public async Task<Titles> GetTitleById(object id)
        {
            await _titleAlias.WhereByTitleId(id.ToString());
            return await _titles.ReadById(id);
        }

        public async Task<List<Titles>> GetPopularTitles(int num, string type)
        {
            return await _titles.GetPopularTitles(num, type);
        }

        public async Task<UserRating> RateTitle(UserRating rating)
        {
            return await _userRatings.Create(rating);
        }

        public async Task<List<Comments>> GetCommentsByTitleId(string id, PaginationFilter filter = null)
        {
            return await _comments.WhereByTitleId(id, filter);
        }

        public async Task<List<TitleInfo>> GetTitleInfoByTitleId(string id)
        {
            return await _titleInfo.WhereByTitleId(id);
        }

        public async Task<List<TitleAlias>> GetTitleAliasByTitleId(string id)
        {
            return await _titleAlias.WhereByTitleId(id);
        }

        public async Task<List<TitleFormats>> GetTitleFormatByTitleId(string id)
        {
            return await _titleFormat.WhereByTitleId(id);
        }

        public async Task<List<Titles>> SearchForTitle(int? num, string searchString)
        {
            return await _titles.SearchForTitle(num, searchString);
        }

        public async Task<List<Titles>> GetAllTitles()
        {
            return await _titles.ReadAll();
        }

        public async Task<List<UserRating>> GetUserRatingByTitleId(string titleId, PaginationFilter filter = null)
        {
            return await _userRatings.WhereByTitleId(titleId, filter);
        }


        public async Task<List<UserRating>> GetUserRatingByUserIdAndTitleId(int userId, string titleId, PaginationFilter filter = null)
        {
            return await _userRatings.WhereByUserIdAndTitleId(userId, titleId, filter);
        }

        public async Task<Bookmarks> CreateBookmark(Bookmarks entity)
        {
            return await _bookmarks.Create(entity);
        }

        public async Task<List<Bookmarks>> GetBookmark(string tid, int uid)
        {
            return await _bookmarks.WhereByTitleAndUserId(uid, tid);
        }

        public async Task<Genres> GetGenreByTitleId(string id)
        {
            var genreId = await _titleGenre.WhereByTitleId(id);
            return await _genre.ReadById(genreId.First().GenreId);
        }

        public async Task<List<Genres>> GetAllGenres()
        {
            return await _genre.ReadAll();
        }

        public async Task<List<Formats>> GetAllFormats()
        {
            return await _format.ReadAll();
        }

        public async Task<Formats> GetFormatByTitleId(string id)
        {
            var formatId = await _titleFormat.WhereByTitleId(id);
            return await _format.ReadById(formatId.First().FormatId);
        }

        //User
        public async Task<Users> GetUserById(object id)
        {
            return await _users.ReadById(id);
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _users.ReadAll();
        }

        public async Task<Users> CreateUser(Users entity)
        {
            entity.LastAccess = DateTime.Now;
            entity.AccountCreation = DateTime.Now;
            return await _users.Create(entity);
        }

        public async Task<Users> UpdateUser(object id, Users entity)
        {
            var user = _users.ReadById(id).Result;
            if (entity.Name != null)
                user.Name = entity.Name;
            if (entity.Password != null)
                user.Password = entity.Password;
            if (entity.Salt != null)
                user.Salt = entity.Salt;
            user.DateOfBirth = entity.DateOfBirth;
            if (entity.Email != null)
                user.Email = entity.Email;
            if (entity.Nickname != null)
                user.Nickname = entity.Nickname;
            return await _users.Update(user);
        }

        public async Task<Users> DeleteUser(object id)
        {
            var user = _users.ReadById(id).Result;
            return await _users.Delete(user);
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return await _users.ReadByEmail(email);
        }

        public async Task<Users> ValidateUserByPassword(string email, string password)
        {
            return await _users.ValidatePassword(email, password);
        }

        public async Task<Comments> GetCommentById(int id)
        {
            return await _comments.ReadById(id);
        }

        public async Task<List<Comments>> GetCommentsByUserId(int id, PaginationFilter filter = null)
        {
            return await _comments.WhereByUserId(id, filter);
        }

        public async Task<List<Bookmarks>> GetBookmarksByUserId(int id, PaginationFilter filter = null)
        {
            return await _bookmarks.WhereByUserId(id, filter);
        }

        public async Task<Comments> DeleteComment(int id)
        {
            var entity = _comments.ReadById(id).Result;
            return await _comments.Delete(entity);
        }

        public async Task<List<UserRating>> GetUserRatingsByUserId(int id, PaginationFilter filter = null)
        {
            return await _userRatings.WhereByUserId(id, filter);
        }

        public async Task<Bookmarks> DeleteBookmark(int uid, string tid)
        {
            var bookmark = await _bookmarks.WhereByTitleAndUserId(uid, tid);
            return await _bookmarks.Delete(bookmark.First());
        }

        public async Task<List<SpecialRoles>> GetSpecialRolesByUserId(int id)
        {
            return await _specialRoles.WhereByUserId(id);
        }

        public async Task<List<SpecialRoles>> DeleteSpecialRoleByUserId(int id)
        {
            return await _specialRoles.WhereByUserId(id);
        }

        public async Task<SpecialRoles> CreateSpecialRole(SpecialRoles entity)
        {
            return await _specialRoles.Create(entity);
        }

        public async Task<SpecialRoles> UpdateSpecialRole(SpecialRoles entity)
        {
            return await _specialRoles.Update(entity);
        }

        public async Task<List<SearchHistory>> GetSearchHistoryByUserId(int id, PaginationFilter filter = null)
        {
            return await _searchHistory.WhereByUserId(id, filter);
        }

        public async Task<UserRating> UpdateUserRating(UserRating entity)
        {
            return await _userRatings.Update(entity);
        }

        public async Task<UserRating> DeleteUserRating(int userId, string titleId)
        {
            var userRating = await _userRatings.ReadById(new object[] { userId, titleId });
            return await _userRatings.Delete(userRating);
        }

        public async Task<Comments> CreateComment(Comments entity)
        {
            entity.CommentTime = DateTime.Now;
            await _comments.Create(entity);
            return _comments.WhereByUserId(entity.UserId).Result.Last();
        }

        public async Task<Comments> UpdateComment(int id, Comments comment)
        {
            var entity = _comments.ReadById(id).Result;
            entity.Comment = comment.Comment;
            entity.CommentTime = comment.CommentTime;
            entity.IsEdited = true;
            return await _comments.Update(entity);
        }

        public async Task<FlaggedComment> FlagComment(FlaggedComment comment)
        {

            return await _flaggedComments.Create(comment);
        }

        public async Task<List<FlaggedComment>> GetFlaggedComment(int userId, int commentId)
        {
            return await _flaggedComments.WhereByUserIdAndCommentId(userId, commentId);
        }

        public async Task<FlaggedComment> DeleteFlaggedComment(int userId, int commentId)
        {
            var flaggedComment = await GetFlaggedComment(userId, commentId);
            return await _flaggedComments.Delete(flaggedComment.First());
        }
    }
}
