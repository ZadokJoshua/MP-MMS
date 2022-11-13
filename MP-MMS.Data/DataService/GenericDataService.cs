using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MP_MMS.Domain.Model;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data.DataService
{
    public class GenericDataService<T> : IDataService<T> where T : BaseModel
    {
        public async Task Create(T entity)
        {
            using (MPMMSDbContext context = new())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Delete(T entity)
        {
            using (MPMMSDbContext context = new())
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (MPMMSDbContext context = new())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> GetById(int id)
        {
            using (MPMMSDbContext context = new())
            {
                T entity = await context.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();
                return entity;
            }
        }

        public async Task Update(T entity)
        {
            using (MPMMSDbContext context = new())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
