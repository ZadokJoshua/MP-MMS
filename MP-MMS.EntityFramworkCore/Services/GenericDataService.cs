using Microsoft.EntityFrameworkCore;
using MP_MMS.Domain.Model;
using MP_MMS.Domain.Service;

namespace MP_MMS.EntityFramworkCore.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly MP_MMSDbContextFactory _contextFactory;

        public GenericDataService(MP_MMSDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }


    }
}
