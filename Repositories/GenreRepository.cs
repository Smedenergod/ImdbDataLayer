using IMDBDataService.DMO;

namespace IMDBDataService.Repositories
{
    class GenreRepository : GenericRepository<Genres>
    {
        public GenreRepository(ImdbContext context) : base(context)
        {

        }
    }
}
