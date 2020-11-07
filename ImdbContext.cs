using System;
using System.IO;
using IMDBDataService.CustomTypes;
using IMDBDataService.Objects;
using Microsoft.EntityFrameworkCore;
using Npgsql;


namespace IMDBDataService
{
    public class ImdbContext : DbContext
    {
        public DbSet<Titles> Titles { get; set; }
        public DbSet<TitleInfo> TitleInfo { get; set; }
        public DbSet<TitleAlias> TitleAlias { get; set; }
        public DbSet<Formats> Formats { get; set; }
        public DbSet<TitleFormats> TitleFormats { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<TitleGenres> TitleGenres { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<CastInfo> CastInfo { get; set; }
        public DbSet<Casts> Casts { get; set; }
        public DbSet<CastProfession> CastProfession { get; set; }
        public DbSet<CastKnownFor> CastKnownFor { get; set; }
        public DbSet<SpecialRoles> SpecialRoles { get; set; }
        public DbSet<Bookmarks> Bookmarks { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }

        public string connectionString = "host=localhost;database=imdb_local;user id=postgres;password = secret;";



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BookmarkType>("bookmark_enum");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Titles
            modelBuilder.Entity<Titles>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titles");

                //Sets Primary Key
                entity.HasKey(x => x.title_id).HasName("title_id");

                //Sets properties
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.primary_title).HasColumnName("primary_title");
                entity.Property(x => x.is_adult).HasColumnName("is_adult");
                entity.Property(x => x.original_title).HasColumnName("original_title");
                entity.Property(x => x.poster).HasColumnName("poster");
                entity.Property(x => x.start_year).HasColumnName("start_year").ToString();
                entity.Property(x => x.year_end).HasColumnName("end_year").ToString();
                entity.Property(x => x.runtime_mins).HasColumnName("runtime_mins");
                entity.Property(x => x.title_type).HasColumnName("title_type");
            });

            //TitleInfo
            modelBuilder.Entity<TitleInfo>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titleinfo");

                //Sets Primary Key
                entity.HasKey(x => x.title_id).HasName("title_id");

                //Sets properties
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.awards).HasColumnName("awards");
                entity.Property(x => x.plot).HasColumnName("plot");

                //Sets Foreign Keys
                entity.HasOne(x => x.titles).WithMany(d => d.TitleInfo)
                    .HasForeignKey(x => x.title_id);
            });


            //TitleAlias
            modelBuilder.Entity<TitleAlias>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titlesalias");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.title_id, x.ordering });

                //Sets properties
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.ordering).HasColumnName("ordering");
                entity.Property(x => x.title).HasColumnName("title");
                entity.Property(x => x.region).HasColumnName("region");
                entity.Property(x => x.language).HasColumnName("language");
                entity.Property(x => x.attributes).HasColumnName("attributes");
                entity.Property(x => x.is_original_title).HasColumnName("is_original_title");

                //Sets Foreign Keys
                entity.HasOne(x => x.titles).WithMany(d => d.TitleAlias)
                    .HasForeignKey(x => x.title_id);
            });

            //Genres
            modelBuilder.Entity<Genres>(entity =>
            {
                //Points To Database Table
                entity.ToTable("genres");

                //Sets Primary Key
                entity.HasKey(x => x.genre_id).HasName("pk_genres");

                //Sets properties
                entity.Property(x => x.genre_id).HasColumnName("genre_id");
                entity.Property(x => x.genre).HasColumnName("genre");
            });

            //TitleGenres
            modelBuilder.Entity<TitleGenres>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titlegenres");

                //Sets Primary Key
                entity.HasKey(x => x.title_id).HasName("title_id");

                //Sets properties
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.genre_id).HasColumnName("genre_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.title).WithMany(d => d.TitleGenre)
                    .HasForeignKey(x => x.title_id);
                entity.HasOne(x => x.genre).WithMany(d => d.TitleGenres)
                    .HasForeignKey(x => x.genre_id);
            });

            //Formats
            modelBuilder.Entity<Formats>(entity =>
            {
                //Points To Database Table
                entity.ToTable("formats");

                //Sets Primary Key
                entity.HasKey(x => x.format_id).HasName("pk_formats");

                //Sets properties
                entity.Property(x => x.format_id).HasColumnName("format_id");
                entity.Property(x => x.format).HasColumnName("format");
            });

            //TitleFormats
            modelBuilder.Entity<TitleFormats>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titleformats");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.title_id, x.ordering });

                //Sets properties
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.ordering).HasColumnName("ordering");
                entity.Property(x => x.format_id).HasColumnName("format_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.titleAlias).WithMany(d => d.TitleFormat)
                    .HasForeignKey(x => new { x.title_id, x.ordering });
                entity.HasOne(x => x.format).WithMany(d => d.TitleFormats)
                    .HasForeignKey(x => x.format_id);
            });

            //CastInfo
            modelBuilder.Entity<CastInfo>(entity =>
            {
                //Points To Database Table
                entity.ToTable("castinfo");

                //Sets Primary Key
                entity.HasKey(x => x.cast_id).HasName("cast_id");

                //Sets properties
                entity.Property(x => x.cast_id).HasColumnName("cast_id");
                entity.Property(x => x.name).HasColumnName("name");
                entity.Property(x => x.birth_year).HasColumnName("birth_year").ToString();
                entity.Property(x => x.death_year).HasColumnName("death_year").ToString();
            });

            //CastProfession
            modelBuilder.Entity<CastProfession>(entity =>
            {
                //Points To Database Table
                entity.ToTable("castprofession");

                //Sets Primary Key
                entity.HasKey(x => x.cast_id).HasName("cast_id");

                //Sets properties
                entity.Property(x => x.cast_id).HasColumnName("cast_id");
                entity.Property(x => x.profession).HasColumnName("profession");

                //Sets Foreign Keys
                entity.HasOne(x => x.castInfo).WithMany(d => d.CastProfession).HasForeignKey(x => x.cast_id);
            });

            //CastKnownFor
            modelBuilder.Entity<CastKnownFor>(entity =>
            {
                //Points To Database Table
                entity.ToTable("castknownfor");

                //Sets Primary Key
                entity.HasKey(x => x.cast_id).HasName("cast_id");

                //Sets properties
                entity.Property(x => x.cast_id).HasColumnName("cast_id");
                entity.Property(x => x.known_for).HasColumnName("known_for");

                //Sets Foreign Keys
                entity.HasOne(x => x.castInfo).WithMany(d => d.CastKnownFor).HasForeignKey(x => x.cast_id);
            });

            //Casts
            modelBuilder.Entity<Casts>(entity =>
            {
                //Points To Database Table
                entity.ToTable("casts");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.title_id, x.ordering });

                //Sets properties
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.ordering).HasColumnName("ordering");
                entity.Property(x => x.category).HasColumnName("category");
                entity.Property(x => x.job).HasColumnName("job");
                entity.Property(x => x.char_name).HasColumnName("char_name");

                //Sets Foreign Keys
                entity.HasOne(x => x.title).WithMany(d => d.Casts).HasForeignKey(x => x.title_id);
                entity.HasOne(x => x.castInfo).WithMany(d => d.Casts).HasForeignKey(x => x.cast_id);
            });

            //Episodes
            modelBuilder.Entity<Episodes>(entity =>
            {
                //Points To Database Table
                entity.ToTable("episodes");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.episode_id, x.series_id });

                //Sets properties
                entity.Property(x => x.episode_id).HasColumnName("episode_id");
                entity.Property(x => x.series_id).HasColumnName("series_id");
                entity.Property(x => x.season_num).HasColumnName("season_num");
                entity.Property(x => x.episode_num).HasColumnName("episode_num");

                //Sets Foreign Keys
                entity.HasOne(x => x.episode).WithMany(d => d.Episodes).HasForeignKey(x => x.episode_id);
                entity.HasOne(x => x.series).WithMany(d => d.Seasons).HasForeignKey(x => x.series_id);
            });

            //Users
            modelBuilder.Entity<Users>(entity =>
            {
                //Points To Database Table
                entity.ToTable("users");

                //Sets Primary Key
                entity.HasKey(x => x.user_id).HasName("user_id");

                //Sets properties
                entity.Property(x => x.user_id).HasColumnName("user_id");
                entity.Property(x => x.user_name).HasColumnName("user_name");
                entity.Property(x => x.date_of_birth).HasColumnName("date_of_birth").HasColumnType("date");
                entity.Property(x => x.derived_age).HasColumnName("derived_age");
                entity.Property(x => x.nickname).HasColumnName("nickname");
                entity.Property(x => x.account_creation).HasColumnName("account_creation");
                entity.Property(x => x.last_access).HasColumnName("last_access");
                entity.Property(x => x.email).HasColumnName("email");
                entity.Property(x => x.user_pass).HasColumnName("user_password");
                entity.Property(x => x.salt).HasColumnName("salt");
            });

            //Bookmarks
            modelBuilder.Entity<Bookmarks>(entity =>
            {
                //Points To Database Table
                entity.ToTable("bookmarks");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.user_id, x.type_id });

                //Sets properties
                entity.Property(x => x.user_id).HasColumnName("user_id");
                entity.Property(x => x.bookmark_type).HasColumnName("bookmark_type");
                entity.Property(x => x.type_id).HasColumnName("type_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.Bookmarks).HasForeignKey(x => x.user_id);
                entity.HasOne(x => x.Title).WithMany(d => d.Bookmarks).HasForeignKey(x => x.type_id);
            });

            //SpecialRoles
            modelBuilder.Entity<SpecialRoles>(entity =>
            {
                //Points To Database Table
                entity.ToTable("specialroles");

                //Sets Primary Key
                entity.HasKey(x => x.user_id).HasName("user_id");

                //Sets properties
                entity.Property(x => x.user_id).HasColumnName("user_id");
                entity.Property(x => x.role_type).HasColumnName("role_type");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.SpecialRoles).HasForeignKey(x => x.user_id);
            });

            //UserRating
            modelBuilder.Entity<UserRating>(entity =>
            {
                //Points To Database Table
                entity.ToTable("userrating");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.user_id, x.title_id });

                //Sets properties
                entity.Property(x => x.user_id).HasColumnName("user_id");
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.score).HasColumnName("score");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.UserRating).HasForeignKey(x => x.user_id);
                entity.HasOne(x => x.Title).WithMany(d => d.UserRating).HasForeignKey(x => x.title_id);
            });

            //SearchHistory
            modelBuilder.Entity<SearchHistory>(entity =>
            {
                //Points To Database Table
                entity.ToTable("searchhistory");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.UserId, x.Ordering});

                //Sets properties
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.SearchString).HasColumnName("query_string");
                entity.Property(x => x.SearchTime).HasColumnName("search_time");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.SearchHistories).HasForeignKey(x => x.UserId);
            });

            //Comments
            modelBuilder.Entity<Comments>(entity =>
            {
                //Points To Database Table
                entity.ToTable("comments");

                //Sets Primary Key
                entity.HasKey(x => x.comment_id).HasName("comment_id");

                //Sets properties
                entity.Property(x => x.comment_id).HasColumnName("comment_id");
                entity.Property(x => x.comment_time).HasColumnName("comment_time").HasColumnType("date");
                entity.Property(x => x.user_id).HasColumnName("user_id");
                entity.Property(x => x.title_id).HasColumnName("title_id");
                entity.Property(x => x.comment).HasColumnName("comment_string");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.Comments).HasForeignKey(x => x.user_id);
                entity.HasOne(x => x.Title).WithMany(d => d.Comments).HasForeignKey(x => x.title_id);
            });
        }
    }
}
