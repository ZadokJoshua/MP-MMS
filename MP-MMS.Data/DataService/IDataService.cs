using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data.DataService
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task Create(T entity);

        Task Update(T entity);

        Task<bool> Delete(T entity);  
    }
}
