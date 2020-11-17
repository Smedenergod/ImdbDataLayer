using DataService.DAL.DMO;

namespace DataService.DAL.Repositories
{
    class FormatRepository : GenericRepository<Formats>
    {
        public FormatRepository(Context context) : base(context)
        {

        }
    }
}
