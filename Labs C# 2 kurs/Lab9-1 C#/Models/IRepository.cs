using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public interface IRepository<T>
        where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Create(Type value);

        Task<T> Delete(int id);

        Task<T> Update(int id, Type value);
    }
}
