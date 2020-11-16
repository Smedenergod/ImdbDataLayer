using IMDBDataService.DMO;

namespace IMDBDataService.Repositories
{
    class EpisodeRepository : GenericRepository<Episodes>
    {
        public EpisodeRepository(ImdbContext context) : base(context)
        {

        }
    }
}
