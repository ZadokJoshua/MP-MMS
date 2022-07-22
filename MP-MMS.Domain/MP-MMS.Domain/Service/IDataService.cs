using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Domain.Service
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T entity);

        Task<T> GetById(int id);

        Task<T> Update(int id, T entity);
        
        Task<T> Delete(T entity);
    }
}
