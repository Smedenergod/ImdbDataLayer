using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMDBDataService.Repositories
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        private readonly ImdbContext context;

        public GenericRepository(ImdbContext context)
        {
            this.context = context;
        }
        public async Task<T> ReadById(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        /*
        public async Task<T> Read(string id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        */
        public async Task<List<T>> ReadAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async void Save()
        {
            await context.SaveChangesAsync();
        }

    }
}
