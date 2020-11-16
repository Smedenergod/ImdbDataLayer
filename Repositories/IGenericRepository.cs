using System.Collections.Generic;
using System.Threading.Tasks;
using IMDBDataService.Filters;

namespace IMDBDataService.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> ReadAll(PaginationFilter paginationFilter = null);
        Task<int> CountAll();
        Task<T> ReadById(object id);
        Task<T> ReadById(object[] id); 
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        void Save();
    }
}
