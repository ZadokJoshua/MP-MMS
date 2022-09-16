using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        void Create(T entity);

        void Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
