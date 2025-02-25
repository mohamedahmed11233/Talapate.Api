using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;
using Talapate.Core.specification;

namespace Talapate.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> spec);
        Task<T> GetByIdWithSpecAsync(Ispecification<T> spec);

    }
}
