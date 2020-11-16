using IMDBDataService.DMO;

namespace IMDBDataService.Repositories
{
    class FormatRepository : GenericRepository<Formats>
    {
        public FormatRepository(ImdbContext context) : base(context)
        {

        }
    }
}
