using AutoMapper;
using DataService.BLL.DTO;
using DataService.DAL.DMO;

namespace DataService.BLL.Mapper
{
    class Mapper
    {
        public readonly MapperConfiguration Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Titles, TitleDto>();
            cfg.CreateMap<Comments, CommentDto>();
            cfg.CreateMap<CommentForCreateOrUpdateDto, Comments>();
            cfg.CreateMap<CommentDto, Comments>();
            cfg.CreateMap<Bookmarks, BookmarkDto>();
            cfg.CreateMap<BookmarkForCreateDto, Bookmarks>();
            cfg.CreateMap<BookmarkDto, Bookmarks>();
            cfg.CreateMap<Bookmarks, BookmarkForCreateDto>();
            cfg.CreateMap<CastInfo, CastInfoDto>();
            cfg.CreateMap<CastKnownFor, CastKnownForDto>();
            cfg.CreateMap<CastProfession, CastProfessionDto>();
            cfg.CreateMap<Casts, CastDto>();
            cfg.CreateMap<FlaggedComment, FlaggedCommentDto>();
            cfg.CreateMap<FlaggedCommentForCreateDto, FlaggedComment>();
            cfg.CreateMap<Formats, FormatDto>();
            cfg.CreateMap<FormatDto, Formats>();
            cfg.CreateMap<Genres, GenreDto>();
            cfg.CreateMap<GenreDto, Genres>();
            cfg.CreateMap<NameRating, NameRatingDto>();
            cfg.CreateMap<NameRatingDto, NameRating>();
            cfg.CreateMap<SearchHistory, SearchHistoryDto>();
            cfg.CreateMap<SpecialRoles, SpecialRoleDto>();
            cfg.CreateMap<SpecialRoleDto, SpecialRoles>();
            cfg.CreateMap<TitleAlias, TitleAliasDto>();
            cfg.CreateMap<TitleFormats, TitleFormatDto>();
            cfg.CreateMap<TitleGenres, TitleGenreDto>();
            cfg.CreateMap<TitleInfo, TitleInfoDto>();
            cfg.CreateMap<Titles, TitleDto>();
            cfg.CreateMap<Titles, TitlesForFrontPageDto>();
            cfg.CreateMap<Users, UserDto>();
            cfg.CreateMap<UserForCreateOrUpdateDto, Users>();
        });
    }
}
