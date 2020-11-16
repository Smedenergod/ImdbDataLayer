﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.DMO;
using IMDBDataService.Filters;
using IMDBDataService.Repositories;

namespace IMDBDataService.BusinessLogic
{
    public class TitleDataService : ITitlesDataService
    {
        private readonly TitleRepository _titles;
        private readonly CastInfoRepository _castInfo;
        private readonly UserRatingRepository _userRating;
        private readonly TitleFormatRepository _titleFormat;
        private readonly TitleGenreRepository _titleGenre;
        private readonly GenreRepository _genre;
        private readonly FormatRepository _format;

        private readonly TitleAliasRepository _titleAlias;
        private readonly TitleInfoRepository _titleInfo;
        private readonly IGenericRepository<Episodes> _episodes;
        private readonly CommentsRepository _comments;
        private readonly CastsRepository _casts;
        private readonly BookmarkRepository _bookmarks;
        private readonly FlaggedCommentsRepository _flaggedComments;

        public TitleDataService()
        {
            var context = new ImdbContext();
            _castInfo = new CastInfoRepository(context);
            _titles = new TitleRepository(context);
            _casts = new CastsRepository(context);
            _genre = new GenreRepository(context);
            _format = new FormatRepository(context);
            _userRating = new UserRatingRepository(context);
            _titleFormat = new TitleFormatRepository(context);
            _titleGenre = new TitleGenreRepository(context);
            _titleAlias = new TitleAliasRepository(context);
            _titleInfo = new TitleInfoRepository(context);
            _episodes = new GenericRepository<Episodes>(context);
            _comments = new CommentsRepository(context);
            _bookmarks = new BookmarkRepository(context);
            _flaggedComments = new FlaggedCommentsRepository(context);
        }

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
            return await _userRating.Create(rating); ;
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
            return await _userRating.WhereByTitleId(titleId, filter);
        }


        public async Task<List<UserRating>> GetUserRatingByUserIdAndTitleId(int userId, string titleId, PaginationFilter filter = null)
        {
            return await _userRating.WhereByUserIdAndTitleId(userId, titleId, filter);
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
    }
}
