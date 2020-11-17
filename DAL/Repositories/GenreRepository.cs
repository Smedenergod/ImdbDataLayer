using DataService.DAL.DMO;

namespace DataService.DAL.Repositories
{
    class GenreRepository : GenericRepository<Genres>
    {
        public GenreRepository(Context context) : base(context)
        {

        }
    }
}
