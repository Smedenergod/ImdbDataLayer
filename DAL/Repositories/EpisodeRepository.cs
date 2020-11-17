using DataService.DAL.DMO;

namespace DataService.DAL.Repositories
{
    class EpisodeRepository : GenericRepository<Episodes>
    {
        public EpisodeRepository(Context context) : base(context)
        {

        }
    }
}
