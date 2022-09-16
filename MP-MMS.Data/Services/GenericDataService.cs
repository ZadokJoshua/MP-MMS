using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data.Services
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly MPMMSDbContextFactory _dbContextFactory;

        public GenericDataService(MPMMSDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
